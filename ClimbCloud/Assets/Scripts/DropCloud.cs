using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCloud : MonoBehaviour
{
    [Tooltip("雨を落とす間隔")]
    [SerializeField] float dropInterval = 0.1f;
    float count = 0;// 時間計測用の変数
    [Tooltip("雨水のオブジェクト")]
    [SerializeField] GameObject rainObj;
    [Tooltip("雨水を落とす位置を調整する用")]
    [Range(-5, 0)]
    [SerializeField] float dropOffSetY;
    [Tooltip("雲レイヤー")]
    [SerializeField] LayerMask cloudLayer; // チェック用のレイヤー
    [SerializeField] bool thunder = false;
    [SerializeField] float rayLength = 1;
    [SerializeField] Vector3 rayOffSet;
    Vector3 thunderPosi;

    BoxCollider2D box;
    SpriteRenderer sr;

    void Start()
    {
        if (thunder)
        {
            box = rainObj.GetComponent<BoxCollider2D>();
            sr = rainObj.GetComponent<SpriteRenderer>();
        }
    }

    void Update()
    {
        TimeCount();
    }

    private void FixedUpdate()
    {
        if (thunder)
        {
            Vector3 startPos = transform.position + rayOffSet;
            Vector3 endPos = startPos;
            // 終了地点に線の長さを加算
            endPos.y += rayLength;
            // 開始地点、終了地点、色を指定して線を描く
            Debug.DrawLine(startPos, endPos, Color.red);

            // 線を飛ばした結果を取得する
            RaycastHit2D hit = Physics2D.Linecast(startPos, endPos, cloudLayer);
            // 当たったかチェック
            if (hit.collider != null)
            {
                Vector3 hitPosi = hit.point;
                //Debug.Log(hitPosi);

                thunderPosi = (transform.position - hitPosi) / 2;
                sr.size = new Vector2(1, thunderPosi.y * 2);
                box.size = new Vector2(1, thunderPosi.y * 2);
                thunderPosi.x = 0;
                thunderPosi.z = 0;
            }
        }
    }

    // 時間計測
    void TimeCount()
    {
        // 時間を加算する
        count += Time.deltaTime;
        // 設定時間を超えた場合
        if (count >= dropInterval)
        {
            if (!thunder)
            {
                // 雨水をx軸にランダムな
                float rx = Random.Range(-0.5f, 0.6f);
                Vector3 offset = new Vector3(rx, dropOffSetY, 0);
            }
            // 雨水を生成する
            Instantiate(rainObj, transform.position - thunderPosi, Quaternion.identity);
            // カウントリセット
            count = 0;
        }
    }
}
