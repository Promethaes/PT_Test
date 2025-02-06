using System.Collections.Generic;
using UnityEngine;
namespace PtTest
{
    public class TargetSpawner : MonoBehaviour
    {
        [SerializeField] int _poolSize = 5000;

        [Header("References")]
        [SerializeField] GameObject _targetPrefab;
        [SerializeField] GameManager _gameManager;
        [SerializeField] BoxCollider _spawnCube;

        List<Target> _targets = new();
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //spawn targets
            for (int i = 0; i < _poolSize; i++)
            {
                var target = Instantiate(_targetPrefab, transform);
                Target targetComponent = target.GetComponent<Target>();
                InitializeTarget(targetComponent);
                _targets.Add(targetComponent);
            }
            //turn targets off at the end of the game
            GameManager.OnGameEnd.AddListener(() => gameObject.SetActive(false));
        }

        private void InitializeTarget(Target target)
        {
            target.transform.position = GetPointInBox();
            target.SpawnPos = target.transform.position;
            target.Velocity = Random.Range(10, 21) * -Vector3.forward;
        }

        Vector3 GetPointInBox()
        {
            var mesh = _spawnCube.GetComponent<MeshRenderer>();
            var bounds = mesh.bounds;
            var bottomLeft = bounds.min;
            var topRight = bounds.max;

            return RandomRange(bottomLeft, topRight);

        }

        Vector3 RandomRange(Vector3 left, Vector3 right)
        {
            Vector3 result = new();
            result.x = Random.Range((int)left.x, (int)right.x);
            result.y = Random.Range((int)left.y, (int)right.y);
            result.z = Random.Range((int)left.z, (int)right.z);

            return result;
        }
    }
}