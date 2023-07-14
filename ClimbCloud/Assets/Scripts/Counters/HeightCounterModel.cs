using UnityEngine;

namespace HeightCounters
{
    public class HeightCounterModel : MonoBehaviour
    {
        public int Tidemark { get { return _tidemark; } }

        // 最高到達点
        private int _tidemark = 0;

        public int CurrentHeight { get { return _currentHeight; } }

        // 現在の高さ
        private int _currentHeight = 0;

        public void SetCounter(int playerPositionY)
        {
            // 最高到達点よりさらに高かったら更新
            if (_tidemark < playerPositionY)
            {
                _tidemark = playerPositionY;
            }

            _currentHeight = playerPositionY;
        }
    }
}