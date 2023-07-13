using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_floor : MonoBehaviour
{
    //��肽����
    //�E�����Ɉ��̑��x�œ���������
    //���x�̓C���X�y�N�^�[�Őݒ肵����
    //�}�b�v�O���o���獶����o�Ă���

    //�ړ����̈ړ����x
    [SerializeField, PropertyName("�ړ����鏰�̈ړ����x")]
    private float movespeed = 3f;


    private void Update()
    {
        //9f��X���̃}�b�v�O��z��
        if (this.transform.position.x < 9f)
        {
            //�ړ�����position���}�b�v�O�ɍs���܂ŉE�Ɉړ�������
            this.transform.position += Vector3.left * -movespeed * Time.deltaTime;
        }
        //�����A�}�b�v�O���o����
        else if (this.transform.position.x > 9f)
        {
            //���̃}�b�v�O�Ɉړ�������
            this.transform.position = new Vector2(-9f, transform.position.y);
        }
    }

    //��肽����
    //Player����ɏ���Ă鎞�ꏏ�ɓ���������

    //�ړ����鏰�̃R���C�_�[��Player�ɐG�ꂽ��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Player�̐e��G�ꂽ�ړ����ɂ���
            collision.transform.SetParent(transform);
        }
    }


    // �ړ����鏰�̃R���C�_�[����Player�����ꂽ��
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Player�̐e������
            collision.transform.SetParent(null);
        }
    }
}
