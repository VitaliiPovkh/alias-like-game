using TMPro;
using UnityEngine;

namespace Assets.Scripts.View
{
    public class InputView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputField;

        public void Clear()
        {
            inputField.text = string.Empty;
        }
    }
}
