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
        // �^�C�}�[�����������Ē�~��Ԃɂ���
        ResetTimer();
        StopTimer();

        // �{�^���̃N���b�N�C�x���g��ݒ�
        startButton.onClick.AddListener(StartTimer);
        stopButton.onClick.AddListener(StopTimer);
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
        // �^�C�}�[���J�n����
        startTime = Time.time;
        isRunning = true;

        // �{�^���̏�Ԃ��X�V����
        startButton.interactable = false;
        stopButton.interactable = true;
    }

    public void StopTimer()
    {
        // �^�C�}�[���~����
        isRunning = false;

        // �{�^���̏�Ԃ��X�V����
        startButton.interactable = true;
        stopButton.interactable = false;
    }

    public void ResetTimer()
    {
        // �^�C�}�[�����Z�b�g����
        startTime = 0f;
        isRunning = false;

        // �{�^���̏�Ԃ��X�V����
        startButton.interactable = true;
        stopButton.interactable = false;

        // �^�C�}�[�e�L�X�g�����Z�b�g����
        UpdateTimerText(0f);
    }

    private void UpdateTimerText(float time)
    {
        // ���Ԃ𕪁A�b�A�~���b�ɕϊ����ĕ\������
        int minutes = (int)(time / 60);
        int seconds = (int)(time % 60);
        int milliseconds = (int)((time * 100) % 100);
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }
}
