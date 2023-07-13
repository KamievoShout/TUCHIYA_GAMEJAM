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
    private const float JUMPING_NUM_PLUS = 1500;
    //JumpFouceの操作値を少なくするための加算変数
    private const float JUMPING_NUM_PERCENT = 1200;
    //JumpFouceの操作値を少なくするための乗算変数

    [Tooltip("攻撃範囲横")]
    [SerializeField]private CircleCollider2D SideAttackCollider;

    [Tooltip("攻撃範囲上")]
    [SerializeField]private CircleCollider2D HeadAttackCollider;

    Rigidbody2D rb;
    private Vector2 KNOCKBACK_VECTOR = new Vector2(70, 240);
    //ノックバック処理時の加算座標
    bool NotMoveSwitch = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ColliderChange(false, false);
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
        if(NotMoveSwitch)
        {
            float x = Input.GetAxisRaw("Horizontal");
            Vector2 MoveX = new Vector2(x, 0) * Speed * Time.deltaTime;
            rb.AddForce(MOVE_VECTOR * MoveX);
            if (x != 0) { transform.localScale = new Vector3(x, 1, 1); }
            //移動

            if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && rb.velocity.y == 0)
            {
                float j = JUMPING_NUM_PLUS + JumpFouce * JUMPING_NUM_PERCENT;
                rb.AddForce(new Vector2(0, j) * Time.deltaTime);
            }
            //ジャンプ

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
            //攻撃
        }
    }
    //キー入力動作

    private void ColliderChange(bool head,bool side)
    {
        HeadAttackCollider.enabled = head;
        SideAttackCollider.enabled = side;
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
        if(transform.position.y<=-20)
        {
            SceneManager.LoadScene("Game");
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
        }
    }
    //ノックバック
}
