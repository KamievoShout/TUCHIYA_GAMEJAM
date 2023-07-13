using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Color fadeColor = Color.black;
    [SerializeField] private float fadeSpeedMultiplier = 1.0f;

    Rigidbody2D rigid2D;
    Animator animator;

    [SerializeField] float jumpForce = 0f;      //ジャンプ力
    [SerializeField] float moveForce = 0f;      //歩行速度
    [SerializeField] float maxWalkSpeed = 0f;

    Vector3 dir = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < -10)
        {
            transform.position = new Vector3(0, 0, 0);
            this.rigid2D.AddForce(-transform.up * this.jumpForce);
        }




        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
        {
            this.animator.SetTrigger("JumpTrigger");
            //AddForce:Rigidbodyのメンバ変数の一つで、「オブジェクトに力を加えることができる」メソッド。
            //今回は「transform.up * jumpForce」としているので、上方向にjumpForce分の力が加わる。upは上方向、つまりYと同義で*(0,jumpForce,0)と同じことをしている。
            this.rigid2D.AddForce(transform.up * this.jumpForce);

        }


        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        float speedx = Mathf.Abs(this.rigid2D.velocity.x);


        if (speedx < this.maxWalkSpeed)//AddForceは力をかけ続けるメソッド。続けているとどんどん力が加算されてめちゃくちゃ早くなる。なので、最大速度を変数で設定し、動きが早くなりすぎるのを防いでいる
        {
            this.rigid2D.AddForce(transform.right * key * moveForce);
        }

        if (key != 0) //keyが0じゃない＝押されているとき
        {
            transform.localScale = new Vector3(key, 1, 1);//このオブジェクトのスケールを変更している。keyは右が押されたときは１,左は-1なので、左を押したときに反転することがわかる
        }

        this.animator.speed = speedx / 2.0f;

        if (this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = speedx / 2.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }

        //if(transform.position.y < 10)
        //{
        //    SceneManager.LoadScene("Main");
        //}

    }

    void LeftPlayerController()
    {
        int key = 0;
        if (Input.GetKey(KeyCode.A)) key = 1;
        if (Input.GetKey(KeyCode.D)) key = -1;

        dir = Vector3.zero;
        dir = rigid2D.velocity;
        dir.x = key * moveForce;
        rigid2D.velocity = dir;


        if (Input.GetKeyDown(KeyCode.W))    //ジャンプ
        {
            JumpControll();
        }

        ScaleControll(key);

    }

    void RightPlayerController()
    {
        int key = 0;
        if (Input.GetKey(KeyCode.LeftArrow)) key = 1;
        if (Input.GetKey(KeyCode.RightArrow)) key = -1;

        MoveControll(key);

        ScaleControll(key);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            JumpControll();
        }
    }

    void MoveControll(int key)
    {
        dir = Vector3.zero;
        dir = rigid2D.velocity;
        dir.x = key * moveForce;
        rigid2D.velocity = dir;
    }

    void JumpControll()
    {
        Vector2 vel = rigid2D.velocity;
        vel.y = 0;              //Yの速度を初期化
        rigid2D.velocity = vel;    //上の初期化を反映

        //ジャンプ力を加える
        rigid2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void ScaleControll(int key)
    {
        if (key != 0)
        {
            Vector3 scl = transform.localScale;

            //Mathf.Abs:絶対値のこと
            scl.x = Mathf.Abs(scl.x) * key;       //向き設定
            transform.localScale = scl;               //拡縮設定
        }
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        Initiate.Fade("ClearScene", fadeColor, fadeSpeedMultiplier);
        Debug.Log("Goal");
    }
}

