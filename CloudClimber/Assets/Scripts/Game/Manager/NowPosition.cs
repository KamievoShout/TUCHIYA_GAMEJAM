using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NowPosition : MonoBehaviour
{
    [SerializeField]
    Transform StartPos;
    [SerializeField]
    Transform GoalPos;
    [SerializeField]
    Transform PlayerPos;

    [SerializeField]
    Slider slider;

    private void Update()
    {
        //�X�^�[�g�A�S�[���A�v���C���[position��Y�����擾��������
        float a = StartPos.position.y;
        float b = PlayerPos.position.y;
        float c = GoalPos.position.y;

        //�v���C���[ - �X�^�[�g
        float ba = b - a;
        //�S�[�� - �X�^�[�g
        float ca = c - a;
        
        //����
        float dir = ba / ca;

        //�V�����_�[�Ɋ���������
        slider.value = dir;
        //Debug.Log(dir);
    }
}
