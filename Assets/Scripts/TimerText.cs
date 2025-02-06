using UnityEngine;

namespace PtTest
{
    public class TimerText : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] GameManager _gameManager;
        [SerializeField] TMPro.TextMeshProUGUI _text;

        // Update is called once per frame
        void Update()
        {
            _text.text = _gameManager.GetGameTime().ToString("0.00");
        }
    }
}