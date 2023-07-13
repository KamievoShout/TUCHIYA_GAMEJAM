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
        // �^�C�}�[���J�n����
        StartTimer();
    }

    private void Update()
    {
        if (isRunning)
        {
            // ���݂̌o�ߎ��Ԃ��v�Z���ĕ\������
            float elapsedTime = Time.time - startTime;
            UpdateTimerText(elapsedTime);
        }
    }

    public void StartTimer()
    {
        // �^�C�}�[���J�n����O�ɏ���������
        startTime = Time.time;
        isRunning = true;
    }

    public void StopTimer()
    {
        // �^�C�}�[���~����
        isRunning = false;
    }

    public void ResetTimer()
    {
        // �^�C�}�[�����Z�b�g����
        startTime = Time.time;
    }

    private void UpdateTimerText(float time)
    {
        // ���Ԃ𕪂ƕb�ɕϊ����ĕ\������
        int minutes = (int)(time / 60);
        int seconds = (int)(time % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
