using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectSystem : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField, Header("横でこの座標から")]
    private float horRange1 = 0;
    [SerializeField, Header("横でここまで（必ずこっちの方を大きくする）")]
    private float horRange2 = 0;
    [SerializeField,Header("縦でこの座標から")]
    private float verRange1 =0;
    [SerializeField, Header("縦でここまで")]
    private float verRange2 =0;

    [SerializeField, Header("敵だったらtrueにする")]
    private bool enemy = false;

    [SerializeField,Header("横に動くならtrueにする")]
    private bool hor = false;
    [SerializeField,Header("縦に動くならtrueにする")]
    private bool ver = false;

    private int horkey;
    private int verkey;

    // Start is called before the first frame update
    void Start()
    {
        horkey = 1;
        verkey = 1;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (hor)
            {
                collision.gameObject.transform.position += new Vector3(speed * horkey * Time.deltaTime, 0, 0);//player動かす
            }
        }

        if (enemy == true)
        {
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("ぷれいやしす");//プレイヤーを殺すメソッドなどを呼び出す
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x < horRange1) horkey = 1;//自分の座標が範囲１より小さくなったらkeyを1にする
        else if (transform.position.x > horRange2) horkey = -1;//範囲２より大きくなったら-1にする、keyはspeedにかける

        if (transform.position.y < verRange1) verkey = 1;//上に同じく
        else if (transform.position.y > verRange2) verkey = -1;//上に同じく

        if (hor)
        {
            transform.position += new Vector3(speed * horkey * Time.deltaTime, 0, 0);//よこに動かす
        }
        if (ver)
        {
            transform.position += new Vector3(0, speed * verkey * Time.deltaTime, 0);//たてに動かす
        }
    }
}
