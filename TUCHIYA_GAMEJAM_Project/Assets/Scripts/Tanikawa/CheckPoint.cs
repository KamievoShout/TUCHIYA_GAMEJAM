using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CheckPoint
{
    public class CheckPoint : MonoBehaviour
    {
        [SerializeField]
        private CheckPointStatus checkPointStatus;

        private void Awake()
        {
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //�v���C���[�ƐڐG������
            if (true)
            {
                //���̃`�F�b�N�|�C���g���ŐV�̃`�F�b�N�|�C���g�ɓo�^����B
                checkPointStatus.CheckPosition(transform.position);
            }
        }
    }
}
