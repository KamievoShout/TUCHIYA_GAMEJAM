using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public Button startButton;
    public Button stopButton;

    private float startTime;
    private bool isRunning;

    private void Start()
    {
        // タイマーを初期化して停止状態にする
        ResetTimer();
        StopTimer();

        // ボタンのクリックイベントを設定
        startButton.onClick.AddListener(StartTimer);
        stopButton.onClick.AddListener(StopTimer);
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
        // タイマーを開始する
        startTime = Time.time;
        isRunning = true;

        // ボタンの状態を更新する
        startButton.interactable = false;
        stopButton.interactable = true;
    }

    public void StopTimer()
    {
        // タイマーを停止する
        isRunning = false;

        // ボタンの状態を更新する
        startButton.interactable = true;
        stopButton.interactable = false;
    }

    public void ResetTimer()
    {
        // タイマーをリセットする
        startTime = 0f;
        isRunning = false;

        // ボタンの状態を更新する
        startButton.interactable = true;
        stopButton.interactable = false;

        // タイマーテキストをリセットする
        UpdateTimerText(0f);
    }

    private void UpdateTimerText(float time)
    {
        // 時間を分、秒、ミリ秒に変換して表示する
        int minutes = (int)(time / 60);
        int seconds = (int)(time % 60);
        int milliseconds = (int)((time * 100) % 100);
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }
}
