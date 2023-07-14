using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Tooltip("Player�̃X�s�[�h")]
    [SerializeField] private float Speed=4;

    private Vector2 MOVE_VECTOR=new Vector2(100,0);
    //Speed�̑���l�����Ȃ����邽�߂̕ϐ�

    [Tooltip("Player�̃W�����v��")]
    [SerializeField] private float JumpFouce=5;

    private const float JUMPING_NUM_PERCENT = 70f;
    //JumpFouce�̑���l�����Ȃ����邽�߂̏�Z�ϐ�

    [Tooltip("�U���͈�")]
    [SerializeField]private CircleCollider2D AttackCollider;

    [Tooltip("�U������")]
    [SerializeField]private float ATTACK_TIME = 1f;

    [Tooltip("�U���G�t�F�N�g")]
    [SerializeField] private GameObject HitEffect;

    Rigidbody2D rb;
    private Vector2 KNOCKBACK_VECTOR = new Vector2(70, 240);
    //�m�b�N�o�b�N�������̉��Z���W
    private bool NotMoveflg = false;//�m�b�N�o�b�N����,true=�����Ȃ�
    [Tooltip("�m�b�N�o�b�N���̒�~����")]
    [SerializeField]private float WAIT_TIME = 0.75f;

    [Tooltip("���S����Instance����I�u�W�F�N�g")]
    [SerializeField] private GameObject DeadPlayer;

    Animator animator;
    BoxCollider2D bc;
    [SerializeField] AnimationClip attack;
    AnimationClip cong;//goal�A�j���N���b�v
    SpriteRenderer rend;
    string SceneName;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        AttackCollider.enabled = false;
        rend = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        animator.SetInteger("CatAction", 0);
        animator.SetBool("CatAttack", false);
        bc = GetComponent<BoxCollider2D>();
        bc.enabled = true;
        NotMoveflg = false;
        SceneName = SceneManager.GetActiveScene().name;
    }
    //�R���|�[�l���g�}��
 
    void Update()
    {
        PlayerInput();
        GameOverCheck();
    }

    private void PlayerInput()
    {
        if(!NotMoveflg)
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
            float plx = Mathf.Clamp(this.gameObject.transform.position.x, -3.2f, 3.2f);
            this.gameObject.transform.position = new Vector3(plx,this.gameObject.transform.position.y,0);
            //�ړ�

            if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && rb.velocity.y == 0)
            {
                float j = JumpFouce*JUMPING_NUM_PERCENT;
                Vector2 addJump = new Vector2(0, j);
                //�{���^������Fouce�l�ɐݒ�
                rb.velocity = Vector2.zero;
                rb.AddForce(addJump);
                animator.SetInteger("CatAction", 2);
            }
            //�W�����v

            if(Input.GetKey(KeyCode.Space))
            {
                StartCoroutine(Attack());
            }
            //�U��

            if (rb.velocity.y < 0)
            {
                animator.SetInteger("CatAction", 3);
            }
        }
    }
    //�L�[���͓���

    private IEnumerator Attack()
    {
        animator.Play(attack.name);
        animator.SetBool("CatAttack", true);
        AttackCollider.enabled = true;
        yield return new WaitForSeconds(ATTACK_TIME);
        AttackCollider.enabled = false;
        animator.SetBool("CatAttack", false);
    }
    //�U���R���[�`��

    private void GameOverCheck()
    {
        if(rend.isVisible)
        {
            float dis = 
                Vector2.Distance(transform.position, Camera.main.transform.position);
            if (dis >=5.5f)
            {
                PlayerDead();
            }
        }
    }
    //������x���������烊�^�[��

    private void OnTriggerEnter2D(Collider2D col)
    {
        Instantiate(HitEffect,col.gameObject.transform.position,Quaternion.identity);
    }
    //�U���𓖂Ă���

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(TagCheck(col))
        {
            NotMoveflg = true;
            float f = transform.position.x - col.gameObject.transform.position.x;
            float front = (f<0)?-1:1;
            Vector2 knockback = KNOCKBACK_VECTOR;
            knockback.x *= front;
            rb.velocity = Vector2.zero;
            rb.AddForce(knockback);
            bc.enabled = false;
        }
    }
    //�m�b�N�o�b�N�i�_���[�W�_���S�j

    bool TagCheck(Collision2D col)
    {
        if (col.gameObject.CompareTag("Damage")) return true;
        if (col.gameObject.CompareTag("Thunder")) return true;

        return false;
    }

    public void GroundCheck()
    {
        if(rb.velocity.y == 0)
        {
            animator.SetInteger("CatAction", 0);
        }
    }
    //Velocity.y=0�Ȃ�X�e�C��

    public void PlayerDead()
    {
        Instantiate(DeadPlayer);
        Destroy(this.gameObject);
    }
    //���S�I�u�W�F�N�g����
    private void Conglutination()
    {
        animator.Play(cong.name);
    }
    //�N���A�A�j���Đ��i�\��j
}
