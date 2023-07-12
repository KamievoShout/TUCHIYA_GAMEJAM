using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontroller : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //�W�����v����
        if(Input.GetKeyDown(KeyCode.Space)&&this.rigid2D.velocity.y==0)
        {
            this.animator.SetTrigger("Jump Trigger");
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        // ���E�ړ�
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        // �v���C���̑��x
        // Abs�i���Ԃ����[�Ɓj��Βl��Ԃ�
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        // �X�s�[�h����
        if(speedx<this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }
        // ���̃I�u�W�F�N�g�ɂƂ��ẲE����
        // transform.right x:1,y:0,z:0

        // �E��󂪉����ꂽ�� key��1
        // key 1

        // �ړ����x��walkSpeed 30
        // x:1*1*30 �� 30
        // y:0*1*30 �� 0
        // z:0*1*30 �� 0

        // ���������ɉ����Ĕ��]
        if(key!=0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        // �v���C���̑��x�ɉ����ăA�j���[�V�������x��ς���
        if (this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = speedx / 2.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }
        // ��ʊO�ɏo���ꍇ�͍ŏ�����
        if(transform.position.y<-10)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("�S�[��");
        SceneManager.LoadScene("ClearScene");
    }

}
