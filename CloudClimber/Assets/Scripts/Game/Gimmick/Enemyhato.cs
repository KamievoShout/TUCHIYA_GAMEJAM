using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhato : MonoBehaviour
{
    //��肽����
    //�G�������ō��E�Ɉړ�������
    //�ǂɓ��������甽�΂�����

    #region�@//�C���X�y�N�^�[�Őݒ�
    //�G�̈ړ����x
    [SerializeField,PropertyName("�G�̈ړ����x")]
    private float EnemySpeed = 3.0f;
    #endregion

    private void Start()
    {
        //����rb��Rigidbody2D������
        TryGetComponent(out Rigidbody rb);
    }

    private void Update()
    {
        //�E�Ɉړ�������
        this.transform.position += Vector3.left * -EnemySpeed * Time.deltaTime;
    }

    //�ǂɂԂ������甽�]������
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�v���C���[�ɓ������Ă����]���Ȃ��悤��
        if (!collision.gameObject.CompareTag("Player"))
        {
            //Enemy�̑��x��-1�����Ĕ��]
            EnemySpeed = EnemySpeed * -1;
            //
            this.transform.Rotate(Vector3.up, this.transform.rotation.y + 180);
        }
    }
}
