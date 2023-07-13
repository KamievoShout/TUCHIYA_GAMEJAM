using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Tooltip("Player�̃X�s�[�h")]
    [SerializeField] private float Speed;

    private Vector2 MOVE_VECTOR=new Vector2(100,0);
    //Speed�̑���l�����Ȃ����邽�߂̕ϐ�

    [Tooltip("Player�̃W�����v��")]
    [SerializeField] private float JumpFouce;
    private const float JUMPING_NUM_PLUS = 1500;
    //JumpFouce�̑���l�����Ȃ����邽�߂̉��Z�ϐ�
    private const float JUMPING_NUM_PERCENT = 1200;
    //JumpFouce�̑���l�����Ȃ����邽�߂̏�Z�ϐ�

    [Tooltip("�U���͈͉�")]
    [SerializeField]private CircleCollider2D SideAttackCollider;

    [Tooltip("�U���͈͏�")]
    [SerializeField]private CircleCollider2D HeadAttackCollider;

    Rigidbody2D rb;
    private Vector2 KNOCKBACK_VECTOR = new Vector2(70, 240);
    //�m�b�N�o�b�N�������̉��Z���W
    bool NotMoveSwitch = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ColliderChange(false, false);
    }
    //�R���|�[�l���g�}��
 
    void Update()
    {
        PlayerInput();
        PlayerWarp();
        GameOverCheck();
    }

    private void PlayerInput()
    {
        if(NotMoveSwitch)
        {
            float x = Input.GetAxisRaw("Horizontal");
            Vector2 MoveX = new Vector2(x, 0) * Speed * Time.deltaTime;
            rb.AddForce(MOVE_VECTOR * MoveX);
            if (x != 0) { transform.localScale = new Vector3(x, 1, 1); }
            //�ړ�

            if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && rb.velocity.y == 0)
            {
                float j = JUMPING_NUM_PLUS + JumpFouce * JUMPING_NUM_PERCENT;
                rb.AddForce(new Vector2(0, j) * Time.deltaTime);
            }
            //�W�����v

            if (Input.GetKey(KeyCode.Space))
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    ColliderChange(true, false);
                }
                else
                {
                    ColliderChange(false, true);
                }
            }
            else { ColliderChange(false, false); }
            //�U��
        }
    }
    //�L�[���͓���

    private void ColliderChange(bool head,bool side)
    {
        HeadAttackCollider.enabled = head;
        SideAttackCollider.enabled = side;
    }
    //�U���͈͂̕ύX����

    private void PlayerWarp()
    {
        if (transform.position.x > 3.5)
        {
            transform.position -= new Vector3(7, 0,0);
        }
        if (transform.position.x < -3.5) 
        {
            transform.position += new Vector3(7, 0, 0);
        }
    }
    //player�̉�ʒ[���[�v

    private void GameOverCheck()
    {
        if(transform.position.y<=-20)
        {
            SceneManager.LoadScene("Game");
        }
    }
    //������x���������烊�^�[��

    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
    }
    //�U���𓖂Ă���

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Damage"))
        {
            float f = transform.position.x - col.gameObject.transform.position.x;
            float front = (f<0)?-1:1;
            Vector2 knockback = KNOCKBACK_VECTOR;
            knockback.x *= front;
            rb.velocity = Vector2.zero;
            rb.AddForce(knockback);
        }
    }
    //�m�b�N�o�b�N
}
