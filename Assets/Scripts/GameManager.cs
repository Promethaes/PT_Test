using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
namespace PtTest
{
    public class GameManager : MonoBehaviour
    {
        [Header("Game Settings")]
        [SerializeField] float _gameTime = 60.0f;

        [Header("References")]
        [SerializeField] GameObject _resultsPanel;

        public float GetGameTime() => _gameTime;
        public static UnityEvent OnGameEnd = new();

        // Update is called once per frame
        void Update()
        {
            _gameTime -= Time.deltaTime;
            if (_gameTime <= 0)
            {
                //end game
                _resultsPanel.SetActive(true);
                _gameTime = 0;
                gameObject.SetActive(false);
                OnGameEnd.Invoke();
            }
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}