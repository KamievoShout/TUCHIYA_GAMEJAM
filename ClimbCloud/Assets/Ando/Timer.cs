using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    private float timer;
    private bool isRunning;

    public Text timerText;

    private void Update()
    {
        if (isRunning)
        {
            timer += Time.deltaTime;
            UpdateTimerText();
        }
    }

    private void UpdateTimerText()
    {
        timerText.text = "Timer: " + timer.ToString("F2");
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResetTimer()
    {
        timer = 0f;
        UpdateTimerText();
    }
}
