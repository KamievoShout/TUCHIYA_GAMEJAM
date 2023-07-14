using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    // プレイヤーのゴール判定を知りたい
    [SerializeField]
    PlayerController playerController;
    [SerializeField]
    TimeCashAsset timeCashAsset;

    float time = 0;
    public float CurrentTime => time;
    bool isCounting = false;

    public void StartCount()
    {
        isCounting = true;
    }

    void Update()
    {
        if (!isCounting) return;
        time += Time.deltaTime;
        // ゴールしたらカウントをやめてスクリプタブルオブジェクトに代入する
        if (playerController.isGoal)
        {
            timeCashAsset.SetTime(time);
        }
    }
}