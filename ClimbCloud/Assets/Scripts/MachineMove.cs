using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineMove : MonoBehaviour
{
    private Vector3 mousepos; 
    private Vector3 worldpos;
    [Tooltip("�ړ��͈͂̐����E")]
    [SerializeField] private float max = 8f;
    [Tooltip("�ړ��͈͂̐�����")]
    [SerializeField] private float min = 8f;
    void Start()
    {
        
    }


    void Update()
    {
        //���g�̍��W�����u���̕ϐ��ɕۑ�
        Vector3 pos = gameObject.transform.position;
        //�}�E�X�̃|�W�V�������擾
        mousepos = Input.mousePosition;
        //�X�N���[�����W�����[���h���W�ɕϊ�
        worldpos = Camera.main.ScreenToWorldPoint(new Vector3(mousepos.x,0f,0f));
        //���[���h���W��X�����u����X���W�ɐݒ�
        pos.x = worldpos.x;
        //�ړ��͈͂𐧌�
        pos.x = Mathf.Clamp(pos.x, -min, max);
        //���g�̍��W�����u���������W�ɍX�V
        gameObject.transform.position = pos;
    }
}
