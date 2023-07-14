using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Tooltip("Playerのスピード")]
    [SerializeField] private float Speed;

    private Vector2 MOVE_VECTOR=new Vector2(100,0);
    //Speedの操作値を少なくするための変数

    [Tooltip("Playerのジャンプ力")]
    [SerializeField] private float JumpFouce;

    private const float JUMPING_NUM_PERCENT = 70f;
    //JumpFouceの操作値を少なくするための乗算変数

    [Tooltip("攻撃範囲")]
    [SerializeField]private CircleCollider2D AttackCollider;

    [Tooltip("攻撃時間")]
    [SerializeField]private float ATTACK_TIME = 1f;

    Rigidbody2D rb;
    private Vector2 KNOCKBACK_VECTOR = new Vector2(70, 240);
    //ノックバック処理時の加算座標
    bool NotMoveSwitch = false;//操作選別,true=動けない
    [Tooltip("ノックバック時の停止時間")]
    [SerializeField]private float WAIT_TIME = 0.75f;

    Animator animator;
    AnimationClip cong;//goalアニメクリップ
    AnimationClip dead;//deadアニメクリップ
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
        SceneName = SceneManager.GetActiveScene().name;
    }
    //コンポーネント挿入
 
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
            //移動

            if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && rb.velocity.y == 0)
            {
                float j = JumpFouce*JUMPING_NUM_PERCENT;
                Vector2 addJump = new Vector2(0, j);
                //本来与えたいFouce値に設定
                rb.velocity = Vector2.zero;
                rb.AddForce(addJump);
                animator.SetInteger("CatAction", 2);
            }
            //ジャンプ

            if(Input.GetKey(KeyCode.Space))
            {
                StartCoroutine(Attack());
            }
            //攻撃

            if (rb.velocity.y < 0)
            {
                animator.SetInteger("CatAction", 3);
            }
        }
    }
    //キー入力動作

    private IEnumerator Attack()
    {
        animator.SetBool("CatAttack", true);
        AttackCollider.enabled = true;
        yield return new WaitForSeconds(ATTACK_TIME);
        AttackCollider.enabled = false;
        animator.SetBool("CatAttack", false);
    }
    //攻撃コルーチン

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
    //playerの画面端ワープ

    private void GameOverCheck()
    {
        if(rend.isVisible)
        {
            float dis = 
                Vector2.Distance(transform.position, Camera.main.transform.position);
            if (dis >=5.5f)
            {
                Debug.Log("GameOver");
                SceneManager.LoadScene(SceneName);
            }
        }
    }
    //ある程度落下したらリターン

    //private void OnTriggerEnter2D(Collider2D col)
    //{
    //    Destroy(col.gameObject);
    //}
    ////攻撃を当てたら

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
    //ノックバック

    private IEnumerator MovePause()
    {
        NotMoveSwitch = true;
        yield return new WaitForSeconds(WAIT_TIME);
        NotMoveSwitch = false;
    }
    //動作を一定時間制限する

    public void GroundCheck()
    {
        if(rb.velocity.y == 0)
        {
            animator.SetInteger("CatAction", 0);
        }
    }
    //Velocity.y=0ならステイに

    private void PlayerDead()
    {
        animator.Play(dead.name);
    }
    //死亡アニメ再生（予定）
    private void Conglutination()
    {
        animator.Play(cong.name);
    }
    //クリアアニメ再生（予定）
}
