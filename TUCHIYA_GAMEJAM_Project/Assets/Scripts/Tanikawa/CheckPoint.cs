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
            //プレイヤーと接触したら
            if (collision.gameObject.CompareTag("Player"))
            {
                //このチェックポイントを最新のチェックポイントに登録する。
                checkPointStatus.CheckPosition(transform.position);
            }
        }
    }
}
