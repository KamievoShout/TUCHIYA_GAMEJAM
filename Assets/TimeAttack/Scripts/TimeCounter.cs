using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    // �v���C���[�̃S�[�������m�肽��
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
        // �S�[��������J�E���g����߂ăX�N���v�^�u���I�u�W�F�N�g�ɑ������
        if (playerController.isGoal)
        {
            timeCashAsset.SetTime(time);
        }
    }
}