using UnityEngine;


namespace Assets.Scripts.Model
{
    [CreateAssetMenu(menuName = "Assets/QueezWord")]
    public class WordInfo : ScriptableObject
    {
        [SerializeField] private string word;
        [Space(20)]
        [TextArea]
        [SerializeField] private string firstHint;
        [TextArea]
        [SerializeField] private string secondHint;
        [TextArea]
        [SerializeField] private string thirdHint;
        [TextArea]
        [SerializeField] private string fourthHint;


        public string Word => word;
        public string[] Hints => new string[4]
        {
            firstHint,
            secondHint,
            thirdHint,
            fourthHint
        };

    }
}
