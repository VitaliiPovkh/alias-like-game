using Assets.Scripts.Model;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private Quiz quiz;

        [SerializeField] private GameObject mainMenu;
        [SerializeField] private GameObject gameWinodw;

        public void OnStartClick()
        {
            mainMenu.SetActive(false);
            gameWinodw.SetActive(true);

            quiz.ResetQuiz();
            quiz.StartQuiz();
        }
    }
}
