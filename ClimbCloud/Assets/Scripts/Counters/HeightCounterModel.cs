using UnityEngine;

namespace HeightCounters
{
    public class HeightCounterModel : MonoBehaviour
    {
        public float Tidemark { get { return _tidemark; } }

        // �ō����B�_
        private float _tidemark = 0;

        public void SetCounter(float y)
        {
            // �ō����B�_��肳��ɍ���������X�V
            if (_tidemark < y)
            {
                _tidemark = y;
            }
        }
    }
}