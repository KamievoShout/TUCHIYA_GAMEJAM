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

    private void Start()
    {
        if (size == 4)
        {
            // 種状態から開始した場合、雲生成機を親に設定する
            //transform.parent = FindObjectOfType<MachineMove>().transform;
        }
    }

    private void Update()
    {
        ChangeSize();
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("当たり！");
        // 「CloudStatus」がアタッチされているかどうか
        if (collision.gameObject.CompareTag("CreateCloud"))
        {
            Debug.Log("雲！");
            // スクリプト取得
            CloudStatus script = collision.gameObject.GetComponent<CloudStatus>();
            if (script.cloudSize == 4)
            {
                Debug.Log("種！", this);
                // サイズに種のサイズを加算
                size += script.cloudSize;
                // 0～3のサイズ内で収まるようにする
                size = Mathf.Clamp(size, 0, 3);
                // 種を破壊
                Destroy(collision.gameObject);
            }
        }
    }

    // 当たっている間
    private void OnTriggerStay2D(Collider2D collision)
    {
        // タグが「Window」だった場合
        if (collision.CompareTag("Window"))
        {
            // 自身を上昇させる
            transform.position += new Vector3(0, upSpeed, 0);
        }
    }

    // 当たり判定が外れてた瞬間
    private void OnTriggerExit2D(Collider2D collision)
    {
        // 種状態かつタグが「Window」だった場合
        if (size == 4 && collision.CompareTag("Window"))
        {
            // 種から雲に成長
            size = growSize;
            // 親子関係解除
            transform.parent = null;
        }
    }
}
