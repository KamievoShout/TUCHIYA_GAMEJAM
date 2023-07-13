using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhato : MonoBehaviour
{
    //やりたい事
    //敵を自動で左右に移動させる
    //壁に当たったら反対を向く

    #region　//インスペクターで設定
    //敵の移動速度
    [SerializeField,PropertyName("敵の移動速度")]
    private float EnemySpeed = 3.0f;
    #endregion

    private void Start()
    {
        //多分rbにRigidbody2Dを入れる
        TryGetComponent(out Rigidbody rb);
    }

    private void Update()
    {
        //右に移動させる
        this.transform.position += Vector3.left * -EnemySpeed * Time.deltaTime;
    }

    //壁にぶつかったら反転させる
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //プレイヤーに当たっても反転しないように
        if (!collision.gameObject.CompareTag("Player"))
        {
            //Enemyの速度に-1かけて反転
            EnemySpeed = EnemySpeed * -1;
            //
            this.transform.Rotate(Vector3.up, this.transform.rotation.y + 180);
        }
    }
}
