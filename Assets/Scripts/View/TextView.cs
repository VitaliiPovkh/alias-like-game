using UnityEngine;

namespace Assets.Scripts.View
{
    public abstract class TextView : MonoBehaviour
    {
        [SerializeField] private int numberTextLength;

        protected string FormatText(int number)
        {
            string textScore = number.ToString();

            if (textScore.Length < numberTextLength)
            {
                textScore = textScore.Insert(0, new string('0', numberTextLength - textScore.Length));
            }

            return textScore;
        }
    }
}
