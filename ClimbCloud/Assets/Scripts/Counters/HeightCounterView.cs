using UnityEngine;
using UnityEngine.UI;

namespace HeightCounters
{
    [RequireComponent(typeof(Text))]
    public class HeightCounterView : MonoBehaviour
    {
        // ���݂̍�����\������e�L�X�g
        private Text _currentHeightText;

        private void Start()
        {
            _currentHeightText = GetComponent<Text>();
        }

        public void SetCounterView(int currentHeight)
        {
            _currentHeightText.text = $"���݂̍���\n{currentHeight.ToString()}m";
        }
    }
}