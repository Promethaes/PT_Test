using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace PtTest
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] float _moveSpeed = 1.0f;
        [SerializeField] float _rotationSpeed = 0.5f;
        [SerializeField] float _gunRange = 1000f;

        [Header("References")]
        [SerializeField] Transform _cameraTransform;
        [SerializeField] Image _reticle;

        Vector2 _moveDir;
        Vector2 _lookDir;

        int _shotCount = 0;
        int _hitCount = 0;
        public int GetMissCount() => _shotCount - _hitCount;
        public int GetHitCount() => _hitCount;
        public int GetTotalShots() => _shotCount;


        private void Start()
        {
            //locks cursor to game window
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void OnMove(InputAction.CallbackContext obj)
        {
            _moveDir = obj.ReadValue<Vector2>();
        }

        public void OnLook(InputAction.CallbackContext obj)
        {
            _lookDir += obj.ReadValue<Vector2>();
            _lookDir.y = Mathf.Clamp(_lookDir.y, -90, 90);

        }

        public void OnAttack(InputAction.CallbackContext obj)
        {
            Ray ray = new(transform.position + transform.forward, _cameraTransform.forward);
            //Debug.DrawRay(transform.position + transform.forward, _cameraTransform.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, _gunRange, LayerMask.GetMask("Target")))
            {
                //Debug.Log(hitInfo.collider.name);
                hitInfo.collider.gameObject.SetActive(false);
                _hitCount++;
            }
            _shotCount++;
        }

        private void Update()
        {
            transform.position += (transform.forward * _moveDir.y + transform.right * _moveDir.x) * _moveSpeed * Time.deltaTime;

            transform.rotation = Quaternion.Euler(new Vector3(0, _lookDir.x, 0) * _rotationSpeed);
            _cameraTransform.localRotation = Quaternion.Euler(new Vector3(-_lookDir.y, 0, 0) * _rotationSpeed / 2.0f);

            Ray ray = new(transform.position + transform.forward, _cameraTransform.forward);
            bool onTarget = Physics.Raycast(ray, out RaycastHit hitInfo, _gunRange, LayerMask.GetMask("Target"));
            _reticle.color = onTarget ? Color.red : Color.white;

        }
    }
}
