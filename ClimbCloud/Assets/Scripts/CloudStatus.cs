using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudStatus : MonoBehaviour
{
    [SerializeField] int size = 3;   // �_�̑傫��
    public int cloudSize => size;   // size�̓ǂݎ��p�ϐ�
    [Tooltip("���E���E��i�E��j�̉_�I�u�W�F�N�g")]
    [SerializeField] GameObject[] cloudObj = new GameObject[3];
    [Tooltip("����������̃T�C�Y")]
    [SerializeField] int growSize = 3;

    [Tooltip("�_�̏㏸�X�s�[�h")]
    [SerializeField] float upSpeed = 1;

    private void Start()
    {
        if (size == 4)
        {
            // ���Ԃ���J�n�����ꍇ�A�_�����@��e�ɐݒ肷��
            //transform.parent = FindObjectOfType<MachineMove>().transform;
        }
    }

    private void Update()
    {
        ChangeSize();
    }

    // �_�̕\������
    void ChangeSize()
    {
        for (int i = 0; i < cloudObj.Length; i++)
        {
            if (i == size - 1)
                cloudObj[i].SetActive(true);
            else
                cloudObj[i].SetActive(false);
        }
    }

    // �_�̑傫����傫�����鏈��
    public void plusSize(int value)
    {
        size += value;
    }

    // �_�̑傫�������������鏈��
    public void minusSize(int value)
    {
        size -= value;
    }

    // ���������u��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("������I");
        // �uCloudStatus�v���A�^�b�`����Ă��邩�ǂ���
        if (collision.gameObject.CompareTag("CreateCloud"))
        {
            Debug.Log("�_�I");
            // �X�N���v�g�擾
            CloudStatus script = collision.gameObject.GetComponent<CloudStatus>();
            if (script.cloudSize == 4)
            {
                Debug.Log("��I", this);
                // �T�C�Y�Ɏ�̃T�C�Y�����Z
                size += script.cloudSize;
                // 0�`3�̃T�C�Y���Ŏ��܂�悤�ɂ���
                size = Mathf.Clamp(size, 0, 3);
                // ���j��
                Destroy(collision.gameObject);
            }
        }
    }

    // �������Ă����
    private void OnTriggerStay2D(Collider2D collision)
    {
        // �^�O���uWindow�v�������ꍇ
        if (collision.CompareTag("Window"))
        {
            // ���g���㏸������
            transform.position += new Vector3(0, upSpeed, 0);
        }
    }

    // �����蔻�肪�O��Ă��u��
    private void OnTriggerExit2D(Collider2D collision)
    {
        // ���Ԃ��^�O���uWindow�v�������ꍇ
        if (size == 4 && collision.CompareTag("Window"))
        {
            // �킩��_�ɐ���
            size = growSize;
            // �e�q�֌W����
            transform.parent = null;
        }
    }
}
