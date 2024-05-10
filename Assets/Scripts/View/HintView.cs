using TMPro;
using UnityEngine;


namespace Assets.Scripts.View
{
    public class HintView : TextView
    {
        [SerializeField] private TextMeshProUGUI hint;
        [SerializeField] private TextMeshProUGUI hintsLeftLabel;

        public void SetHint(string hintContent)
        {
            hint.text = hintContent;
        }

        public void SetHintsCount(int hintsLeft)
        {
            string labelContent = FormatText(hintsLeft);

            hintsLeftLabel.text = labelContent;
        }
    }
}
