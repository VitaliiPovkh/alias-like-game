using Assets.Scripts.View;
using UnityEngine;

namespace Assets.Scripts.Model
{
    public class PlayerData : MonoBehaviour
    {
        private const string SCORE_ID = "Score";

        [SerializeField] private ScoreView scoreView;

        public int HighestScore { get; private set; }

        private void Start()
        {
            Load();
        }

        private void Save()
        {
            PlayerPrefs.SetInt(SCORE_ID, HighestScore);
        }

        private void Load()
        {
            HighestScore = PlayerPrefs.GetInt(SCORE_ID, 0);
            scoreView.UpdateHighestScoreLabel(HighestScore);
        }

        public void PassScore(int score)
        {
            if (score > HighestScore)
            {
                HighestScore = score;
                scoreView.UpdateHighestScoreLabel(HighestScore);
                Save();
            }
        }

    }
}
