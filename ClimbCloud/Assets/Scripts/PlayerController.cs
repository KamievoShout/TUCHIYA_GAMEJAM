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

    private const float JUMPING_NUM_PERCENT = 3000f;
    //JumpFouceの操作値を少なくするための乗算変数

    [Tooltip("攻撃範囲")]
    [SerializeField]private CircleCollider2D AttackCollider;

    Rigidbody2D rb;
    private Vector2 KNOCKBACK_VECTOR = new Vector2(70, 240);
    //ノックバック処理時の加算座標
    bool NotMoveSwitch = false;//操作選別,true=動けない
    private float WAIT_TIME = 0.75f;//ノックバック時の停止時間

    Animator animator;
    AnimationClip cong;//goalアニメクリップ
    AnimationClip dead;//deadアニメクリップ
    SpriteRenderer rend;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ColliderChange(false);
        rend = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
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
                Vector2 addJump = new Vector2(0, j) * Time.deltaTime;
                //本来与えたいFouce値に設定
                rb.velocity = Vector2.zero;
                rb.AddForce(addJump);
                animator.SetInteger("CatAction", 2);
            }
            //ジャンプ

            bool col = Input.GetKey(KeyCode.Space) ? true : false;
            ColliderChange(col);
            //攻撃

            if (rb.velocity.y != 0)
            {
                animator.SetInteger("CatAction", 3);
            }
        }
    }
    //キー入力動作

    private void ColliderChange(bool attack)
    {
        AttackCollider.enabled =attack;
    }
    //攻撃範囲の変更操作

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
            float dis = Vector2.Distance(transform.position, Camera.main.transform.position);
            if (dis >=5.5f)
            {
                Debug.Log("GameOver");
                SceneManager.LoadScene("Game");
            }
        }
    }
    //ある程度落下したらリターン

    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
    }
    //攻撃を当てたら

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

    private void Conglutination()
    {

    }
}
