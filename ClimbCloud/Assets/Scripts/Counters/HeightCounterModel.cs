using UnityEngine;

namespace HeightCounters
{
    public class HeightCounterModel : MonoBehaviour
    {
        public int Tidemark { get { return _tidemark; } }

        // �ō����B�_
        private int _tidemark = 0;

        public int CurrentHeight { get { return _currentHeight; } }

        // ���݂̍���
        private int _currentHeight = 0;

        public void SetCounter(int playerPositionY)
        {
            // �ō����B�_��肳��ɍ���������X�V
            if (_tidemark < playerPositionY)
            {
                _tidemark = playerPositionY;
            }

            _currentHeight = playerPositionY;
        }
    }
}