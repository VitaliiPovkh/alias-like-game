using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts.View
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private Image timerBar;
        public float TimeLimit { private get; set; }


        public void UpdateBar(float timeLeft)
        {
            float timePercentage = timeLeft / TimeLimit;
            timerBar.fillAmount = timePercentage;
        }
    }
}