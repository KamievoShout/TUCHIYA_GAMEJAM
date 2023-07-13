using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;      //LoadScene���g�����߂ɕK�v�I�I

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;

    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    void Update()
    {
        //�W�����v����
        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
        {
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.AddForce(transform.up *  this.jumpForce);
        }

        //���E�ړ�
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        //�v���C���̑��x
        float sppedx = Mathf.Abs(this.rigid2D.velocity.x);

        //�X�s�[�h����
        if(sppedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        //���������ɉ����Ĕ��]
        if(key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        //�v���C���̑��x�ɉ����ăA�j���[�V�������x��ς���
        if(this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = sppedx / 2.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }

        //��ʊO�ɏo���ꍇ�͍ŏ�����
        if(transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    //�S�[���ɓ���
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("�S�[��");
        //SceneManager.LoadScene("ClearScene");
    }
}
