using UnityEngine;
using UnityEngine.UI;

namespace HeightCounters
{
    [RequireComponent(typeof(Text))]
    public class HeightCounterView : MonoBehaviour
    {
        // 現在の高さを表示するテキスト
        private Text _currentHeightText;

        private void Start()
        {
            _currentHeightText = GetComponent<Text>();
        }

        public void SetCounterView(int currentHeight)
        {
            _currentHeightText.text = $"現在の高さ\n{currentHeight.ToString()}m";
        }
    }
}