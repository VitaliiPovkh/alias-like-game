using Assets.Scripts.Model;
using TMPro;
using UnityEngine;


namespace Assets.Scripts.Controller
{
    public class QuizController : MonoBehaviour
    {
        [SerializeField] private Quiz quiz;

        [SerializeField] private GameObject leavingMenuWindow;
        [SerializeField] private GameObject gameOverWindow;

        [SerializeField] private TMP_InputField inputField;

        private void Start()
        {
            quiz.GameOvered += OnGameOver;
            inputField.onEndEdit.AddListener(value => quiz.Input = value);
        }

        public void OnHintClick()
        {
            quiz.NextHint();
        }

        public void OnAnswerClick()
        {
            quiz.Answer();
        }

        public void OnMenuClick()
        {
            leavingMenuWindow.SetActive(true);
        }

        public void OnGameOver()
        {
            if (leavingMenuWindow.gameObject.activeSelf)
            {
                leavingMenuWindow.SetActive(false);
            }
            gameOverWindow.SetActive(true);
        }


    }
}
