using UnityEngine;

namespace HeightCounters
{
    public class HeightCounterModel : MonoBehaviour
    {
        public float Tidemark { get { return _tidemark; } }

        // 最高到達点
        private float _tidemark = 0;

        public void SetCounter(float y)
        {
            // 最高到達点よりさらに高かったら更新
            if (_tidemark < y)
            {
                _tidemark = y;
            }
        }
    }
}