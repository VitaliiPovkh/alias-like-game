using Assets.Scripts.Model;
using UnityEngine;


namespace Assets.Scripts.Controller
{
    public class GameOverController : MonoBehaviour
    {
        [SerializeField] private Quiz quiz;

        [SerializeField] private GameObject mainMenu;
        [SerializeField] private GameObject gameWinodw;

        [SerializeField] private GameObject gameOverWindow;

        public void OnRetryClick()
        {
            gameOverWindow.SetActive(false);

            quiz.ResetQuiz();
            quiz.StartQuiz();
        }

        public void OnExitClick()
        {
            quiz.ResetQuiz();

            gameOverWindow.SetActive(false);
            gameWinodw.SetActive(false);
            mainMenu.SetActive(true);
        }
    }
}
