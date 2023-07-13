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

    void Start()
    {
        
    }

    void Update()
    {
        TimeCount();
    }

    // 時間計測
    void TimeCount()
    {
        // 時間を加算する
        count += Time.deltaTime;
        // 設定時間を超えた場合
        if (count >= dropInterval)
        {
            // 雨水をx軸にランダムな
            float rx = Random.Range(-0.5f, 0.6f);
            Vector3 offset = new Vector3(rx, dropOffSetY, 0);
            // 雨水を生成する
            Instantiate(rainObj, transform.position + offset, Quaternion.identity);
            // カウントリセット
            count = 0;
        }
    }
}
