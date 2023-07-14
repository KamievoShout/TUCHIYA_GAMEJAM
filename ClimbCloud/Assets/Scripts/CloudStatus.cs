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
    // ���݂̉_�̃X�s�[�h
    float speed = 0;
    [Tooltip("���Ŏ���")]
    [SerializeField] float destroyTime = 5.0f;
    float countTime = 0;
    [Tooltip("��_���ǂ���")]
    public bool seedFlg = false;
    [Tooltip("���ꂽ�_���ǂ���")]
    [SerializeField] bool create = false;

    private void Start()
    {
        if (seedFlg)
        {
            // ���Ԃ���J�n�����ꍇ�A�_�����@��e�ɐݒ肷��
            transform.parent = FindObjectOfType<MachineMove>().transform;
        }
    }

    private void Update()
    {
        ChangeSize();
        if (seedFlg)
        {
            //transform.position += new Vector3(0, upSpeed, 0);
        }
        else
        {
            if (create)
            {
                size = Mathf.Clamp(size, 0, 3);

                countTime += Time.deltaTime;
                if (countTime > destroyTime)
                {
                    Destroy(gameObject);
                }
            }
        }

        // ���g���㏸������
        transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (seedFlg)
        {
            // �uCloudStatus�v���A�^�b�`����Ă��邩�ǂ���
            if (collision.gameObject.CompareTag("Normal") || collision.gameObject.CompareTag("Damage"))
            {
                //Debug.Log("�_�I");
                // �X�N���v�g�擾
                CloudStatus script = collision.transform.parent.GetComponent<CloudStatus>();
                if (!script.seedFlg)
                {
                    //Debug.Log("��I", this);
                    if (script.size == 3)
                    {
                        size = growSize;
                        seedFlg = false;
                    }
                    else
                    {
                        // �T�C�Y�Ɏ�̃T�C�Y�����Z
                        script.plusSize(growSize);
                        // ���j��
                        Destroy(this.gameObject);
                    }
                }
            }
        }
    }

    // �������Ă����
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Normal") || collision.CompareTag("Damage") || collision.CompareTag("CreateCloud"))
        {
            speed = 0;
        }
        else
        {
            // �^�O���uWindow�v�������ꍇ
            if (collision.CompareTag("Window"))
            {
                //Debug.Log("���I");
                speed = upSpeed;
                // �e�q�֌W����
                transform.parent = null;
            }
        }
    }

    // �����蔻�肪�O��Ă��u��
    private void OnTriggerExit2D(Collider2D collision)
    {
        // ���Ԃ��^�O���uWindow�v�������ꍇ
        if (collision.CompareTag("Window"))
        {
            // �킩��_�ɐ���
            size = growSize;
            seedFlg = false;
            // �e�q�֌W����
            transform.parent = null;
            speed = 0;
        }
    }
}
