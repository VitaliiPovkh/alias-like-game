using Assets.Scripts.View;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Model
{
    public class Quiz : MonoBehaviour
    {
        [SerializeField] private ScoreView scoreView;
        [SerializeField] private TimerView timerView;
        [SerializeField] private InputView inputView;
        [SerializeField] private HintView hintView;

        [Tooltip("Time for one question (sec)")]
        [SerializeField] private float timeLimit;
        [SerializeField] private int hintsCount;

        [SerializeField] private int hintCheckpoint;

        [SerializeField] private PlayerData playerData;

        private WordInfo[] words;
        private Queue<WordInfo> quizQueue;

        private WordInfo currentWord;
        private string[] currentHints;
        private int hintIndex;

        private float timeLeft;
        private int hintsLeft;
        private bool isGameStarted;

        public delegate void GameOverHandler();
        public event GameOverHandler GameOvered;

        public int Score { get; private set; }
        public string Input { private get; set; }

        private void Start()
        {
            words = Resources.LoadAll<WordInfo>("words");
            ResetQuiz();

            if (words.Length <= 0)
            {
                timeLeft = 0;
            }          
        }
        

        private void Update()
        {
            if (timeLeft > 0 && isGameStarted)
            {
                timerView.UpdateBar(timeLeft);
            }
        }

        private void FixedUpdate()
        {
            if (timeLeft <= 0)
            {
                GameOvered?.Invoke();  
            }
            else if (isGameStarted)
            {
                timeLeft -= Time.fixedDeltaTime;
            }
        }

        private bool CompareWords(string word, string userInput)
        {
            char[] trashChars = new char[] { ' ', '`', '\'' };

            string tempWord = word.ToLower().Trim(trashChars);
            string tempInput = userInput.ToLower().Trim(trashChars);

            return string.Equals(tempWord, tempInput);
        }

        public void Answer()
        {
            inputView.Clear();
            if (CompareWords(currentWord.Word, Input))
            {
                Score++;
                NextQuestion();
            }
        }

        private void NextQuestion()
        {
            hintIndex = 0;
            timeLeft = timeLimit;

            playerData.PassScore(Score);
            scoreView.UpdateScoreLabel(Score);

            if (Score == hintCheckpoint)
            {
                hintsLeft++;
                hintView.SetHintsCount(hintsLeft);
            }

            currentWord = quizQueue.Dequeue();
            currentHints = Shuffle(currentWord.Hints);

            NextHint();

            if (quizQueue.Count == 0)
            {
                FillQueue();
            }
        }

        public void StartQuiz()
        {
            if (words.Length <= 0) return;

            isGameStarted = true;
        }

        public void ResetQuiz()
        {
            if (words.Length <= 0) return;

            FillQueue();
            timeLeft = timeLimit;
            hintsLeft = hintsCount;
            Score = 0;

            timerView.TimeLimit = timeLimit;
            hintView.SetHintsCount(hintsLeft);

            NextQuestion();

            isGameStarted = false;
        }

   
        public void NextHint()
        {
            if (hintsLeft == 0) return;

            if (hintIndex < currentHints.Length && hintsLeft != 0)
            {
                if (hintIndex != 0)
                {
                    hintsLeft--;
                    hintView.SetHintsCount(hintsLeft);
                }
                hintView.SetHint(currentHints[hintIndex++]);
            }            
        }


        private void FillQueue()
        {
            WordInfo[] shuffledWords = Shuffle(words);
            quizQueue = new Queue<WordInfo>(shuffledWords);
        }

        //Fisher–Yates shuffle
        private T[] Shuffle<T>(T[] array)
        {
            int n = array.Length;
            T[] shuffled = new T[n];

            System.Array.Copy(array, shuffled, n);

            while (n > 1)
            {
                int k = Random.Range(0, n--);
                T temp = shuffled[n];
                shuffled[n] = shuffled[k];
                shuffled[k] = temp;
            }

            return shuffled;
        }

    }
}
