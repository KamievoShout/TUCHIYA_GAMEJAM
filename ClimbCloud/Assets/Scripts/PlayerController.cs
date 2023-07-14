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

    private const float JUMPING_NUM_PERCENT = 3000f;
    //JumpFouce�̑���l�����Ȃ����邽�߂̏�Z�ϐ�

    [Tooltip("�U���͈�")]
    [SerializeField]private CircleCollider2D AttackCollider;

    Rigidbody2D rb;
    private Vector2 KNOCKBACK_VECTOR = new Vector2(70, 240);
    //�m�b�N�o�b�N�������̉��Z���W
    bool NotMoveSwitch = false;//����I��,true=�����Ȃ�
    private float WAIT_TIME = 0.75f;//�m�b�N�o�b�N���̒�~����

    Animator animator;
    AnimationClip cong;//goal�A�j���N���b�v
    AnimationClip dead;//dead�A�j���N���b�v
    SpriteRenderer rend;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ColliderChange(false);
        rend = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
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
        if(!NotMoveSwitch)
        {
            float x = Input.GetAxisRaw("Horizontal");
            Vector2 MoveX = new Vector2(x, 0) * Speed * Time.deltaTime;
            rb.AddForce(MOVE_VECTOR * MoveX);
            if (x != 0) 
            { 
                transform.localScale = new Vector3(x, 1, 1);
                animator.SetInteger("CatAction", 1);
            }
            else
            {
                animator.SetInteger("CatAction", 0);
            }
            //�ړ�

            if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && rb.velocity.y == 0)
            {
                float j = JumpFouce*JUMPING_NUM_PERCENT;
                Vector2 addJump = new Vector2(0, j) * Time.deltaTime;
                //�{���^������Fouce�l�ɐݒ�
                rb.velocity = Vector2.zero;
                rb.AddForce(addJump);
                animator.SetInteger("CatAction", 2);
            }
            //�W�����v

            bool col = Input.GetKey(KeyCode.Space) ? true : false;
            ColliderChange(col);
            //�U��

            if (rb.velocity.y != 0)
            {
                animator.SetInteger("CatAction", 3);
            }
        }
    }
    //�L�[���͓���

    private void ColliderChange(bool attack)
    {
        AttackCollider.enabled =attack;
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
        if(rend.isVisible)
        {
            float dis = Vector2.Distance(transform.position, Camera.main.transform.position);
            if (dis >=5.5f)
            {
                Debug.Log("GameOver");
                SceneManager.LoadScene("Game");
            }
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
            StartCoroutine(MovePause());
        }
    }
    //�m�b�N�o�b�N

    private IEnumerator MovePause()
    {
        NotMoveSwitch = true;
        yield return new WaitForSeconds(WAIT_TIME);
        NotMoveSwitch = false;
    }
    //�������莞�Ԑ�������

    public void GroundCheck()
    {
        if(rb.velocity.y == 0)
        {
            animator.SetInteger("CatAction", 0);
        }
    }

    private void Conglutination()
    {

    }
}
