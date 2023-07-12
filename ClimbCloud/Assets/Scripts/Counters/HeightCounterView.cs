using UnityEngine;
using UnityEngine.UI;

namespace HeightCounters
{
    public class HeightCounterView : MonoBehaviour
    {
        [SerializeField]
        private Text _tidemarkText;

        public void SetCounterView(float tidemark)
        {
            _tidemarkText.text = tidemark.ToString();
        }
    }
}