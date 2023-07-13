using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text timerText;
    private float startTime;
    private bool isRunning;

    private void Start()
    {
        // タイマーを開始する
        StartTimer();
    }

    private void Update()
    {
        if (isRunning)
        {
            // 現在の経過時間を計算して表示する
            float elapsedTime = Time.time - startTime;
            UpdateTimerText(elapsedTime);
        }
    }

    public void StartTimer()
    {
        // タイマーを開始する前に初期化する
        startTime = Time.time;
        isRunning = true;
    }

    public void StopTimer()
    {
        // タイマーを停止する
        isRunning = false;
    }

    public void ResetTimer()
    {
        // タイマーをリセットする
        startTime = Time.time;
    }

    private void UpdateTimerText(float time)
    {
        // 時間を分と秒に変換して表示する
        int minutes = (int)(time / 60);
        int seconds = (int)(time % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
