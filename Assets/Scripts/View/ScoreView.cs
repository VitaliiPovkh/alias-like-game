using TMPro;
using UnityEngine;

namespace Assets.Scripts.View
{
    public class ScoreView : TextView
    {
        
        
        [SerializeField] private TextMeshProUGUI highestScoreCount;

        [SerializeField] private TextMeshProUGUI scoreCountQuiz; 
        [SerializeField] private TextMeshProUGUI scoreCountGameOver;


        
        public void UpdateScoreLabel(int score)
        {
            string labelContent = FormatText(score);

            scoreCountQuiz.text = labelContent;
            scoreCountGameOver.text = labelContent;
        }

        public void UpdateHighestScoreLabel(int score)
        {
            string labelContent = FormatText(score);

            highestScoreCount.text = labelContent;
        }


    }
}
