using Assets.Scripts.Model;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class LeavingMenuController : MonoBehaviour
    {
        [SerializeField] private Quiz quiz;

        [SerializeField] private GameObject mainMenu;
        [SerializeField] private GameObject gameWinodw;

        [SerializeField] private GameObject leavingMenuWindow;


        public void OnReturnClick()
        {
            leavingMenuWindow.SetActive(false);
        }

        public void OnConfirmClick()
        {
            quiz.ResetQuiz();

            leavingMenuWindow.SetActive(false);
            gameWinodw.SetActive(false);
            mainMenu.SetActive(true);              
        }

    }
}
