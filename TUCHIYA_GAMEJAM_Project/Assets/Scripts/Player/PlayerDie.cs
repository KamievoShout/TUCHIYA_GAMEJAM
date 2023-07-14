using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerDie : MonoBehaviour
    {
        private PlayerCore playerCore;
        [SerializeField] GameObject bomber;
        void Start()
        {
            playerCore = GetComponent<PlayerCore>();
            playerCore.OnplayerDie += Die;
        }

        private void Die()
        {
            //死亡エフェクト
            var obj = Instantiate(bomber);
            obj.transform.position = this.transform.position;
            //見えない位置に消し飛ばす
            transform.Translate(new Vector2(100000, 0));
            StartCoroutine(Sporn());
        }
        IEnumerator Sporn()
        {
            yield return new WaitForSeconds(1.0f);
            //復活させる
        }
    }
}
