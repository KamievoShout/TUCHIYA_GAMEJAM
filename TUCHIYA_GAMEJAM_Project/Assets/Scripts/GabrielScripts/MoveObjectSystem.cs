using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectSystem : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField, Header("���ł��̍��W����")]
    private float horRange1 = 0;
    [SerializeField, Header("���ł����܂Łi�K���������̕���傫������j")]
    private float horRange2 = 0;
    [SerializeField,Header("�c�ł��̍��W����")]
    private float verRange1 =0;
    [SerializeField, Header("�c�ł����܂�")]
    private float verRange2 =0;

    [SerializeField, Header("�G��������true�ɂ���")]
    private bool enemy = false;

    [SerializeField,Header("���ɓ����Ȃ�true�ɂ���")]
    private bool hor = false;
    [SerializeField,Header("�c�ɓ����Ȃ�true�ɂ���")]
    private bool ver = false;

    private int horkey;
    private int verkey;

    // Start is called before the first frame update
    void Start()
    {
        horkey = 1;
        verkey = 1;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (hor)
            {
                collision.gameObject.transform.position += new Vector3(speed * horkey * Time.deltaTime, 0, 0);//player������
            }
        }

        if (enemy == true)
        {
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("�Ղꂢ�₵��");//�v���C���[���E�����\�b�h�Ȃǂ��Ăяo��
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x < horRange1) horkey = 1;//�����̍��W���͈͂P��菬�����Ȃ�����key��1�ɂ���
        else if (transform.position.x > horRange2) horkey = -1;//�͈͂Q���傫���Ȃ�����-1�ɂ���Akey��speed�ɂ�����

        if (transform.position.y < verRange1) verkey = 1;//��ɓ�����
        else if (transform.position.y > verRange2) verkey = -1;//��ɓ�����

        if (hor)
        {
            transform.position += new Vector3(speed * horkey * Time.deltaTime, 0, 0);//�悱�ɓ�����
        }
        if (ver)
        {
            transform.position += new Vector3(0, speed * verkey * Time.deltaTime, 0);//���Ăɓ�����
        }
    }
}
