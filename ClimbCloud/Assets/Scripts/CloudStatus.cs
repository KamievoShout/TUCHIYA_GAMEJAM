using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudStatus : MonoBehaviour
{
    [SerializeField] int size = 3;   // 雲の大きさ
    public int cloudSize => size;   // sizeの読み取り用変数
    [Tooltip("小・中・大（・種）の雲オブジェクト")]
    [SerializeField] GameObject[] cloudObj = new GameObject[3];
    [Tooltip("成長した後のサイズ")]
    [SerializeField] int growSize = 3;

    [Tooltip("雲の上昇スピード")]
    [SerializeField] float upSpeed = 1;
    // 現在の雲のスピード
    float speed = 0;
    [Tooltip("消滅時間")]
    [SerializeField] float destroyTime = 5.0f;
    float countTime = 0;
    [Tooltip("種雲かどうか")]
    public bool seedFlg = false;
    [Tooltip("作られた雲かどうか")]
    [SerializeField] bool create = false;

    private void Start()
    {
        if (seedFlg)
        {
            // 種状態から開始した場合、雲生成機を親に設定する
            transform.parent = FindObjectOfType<MachineMove>().transform;
        }
    }

    private void Update()
    {
        ChangeSize();
        if (seedFlg)
        {
            //transform.position += new Vector3(0, upSpeed, 0);
        }
        else
        {
            if (create)
            {
                size = Mathf.Clamp(size, 0, 3);

                countTime += Time.deltaTime;
                if (countTime > destroyTime)
                {
                    Destroy(gameObject);
                }
            }
        }

        // 自身を上昇させる
        transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
    }

    // 雲の表示処理
    void ChangeSize()
    {
        for (int i = 0; i < cloudObj.Length; i++)
        {
            if (i == size - 1)
                cloudObj[i].SetActive(true);
            else
                cloudObj[i].SetActive(false);
        }
    }

    // 雲の大きさを大きくする処理
    public void plusSize(int value)
    {
        size += value;
    }

    // 雲の大きさを小さくする処理
    public void minusSize(int value)
    {
        size -= value;
    }

    // 当たった瞬間
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (seedFlg)
        {
            // 「CloudStatus」がアタッチされているかどうか
            if (collision.gameObject.CompareTag("Normal") || collision.gameObject.CompareTag("Damage"))
            {
                //Debug.Log("雲！");
                // スクリプト取得
                CloudStatus script = collision.transform.parent.GetComponent<CloudStatus>();
                if (!script.seedFlg)
                {
                    //Debug.Log("種！", this);
                    if (script.size == 3)
                    {
                        size = growSize;
                        seedFlg = false;
                    }
                    else
                    {
                        // サイズに種のサイズを加算
                        script.plusSize(growSize);
                        // 種を破壊
                        Destroy(this.gameObject);
                    }
                }
            }
        }
    }

    // 当たっている間
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Normal") || collision.CompareTag("Damage") || collision.CompareTag("CreateCloud"))
        {
            speed = 0;
        }
        else
        {
            // タグが「Window」だった場合
            if (collision.CompareTag("Window"))
            {
                //Debug.Log("風！");
                speed = upSpeed;
                // 親子関係解除
                transform.parent = null;
            }
        }
    }

    // 当たり判定が外れてた瞬間
    private void OnTriggerExit2D(Collider2D collision)
    {
        // 種状態かつタグが「Window」だった場合
        if (collision.CompareTag("Window"))
        {
            // 種から雲に成長
            size = growSize;
            seedFlg = false;
            // 親子関係解除
            transform.parent = null;
            speed = 0;
        }
    }
}
