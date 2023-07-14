using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;      //LoadSceneを使うために必要！！

public class PlayerController1 : MonoBehaviour
{
    Vector3 movePos = Vector3.zero;

    Rigidbody2D rigid2D;
    Animator animator;
    
    // ゲームシーン名
    [SerializeField] private string GameSceneName = "GameScene";
    // 足元の当たり判定補正
    [SerializeField] private float UnderRayAsist = 0.35f;
    // 歩く時に加える力
    [SerializeField] private float WalkForce = 0.15f;
    // 飛ぶときに加える力
    [SerializeField] private float JumpForce = 0.15f;
    // 飛ぶスピード
    [SerializeField] private float JumpSpeed = 1;
    // 重力
    [SerializeField] private float GravityScale = 0.15f;
    [SerializeField] private float airGravityaccelerator = 0.98f;
    private float accelerator;
    // 壁に触れているときにかかる壁との摩擦を加味した重力(としたもの)
    [SerializeField] private float isWallGravityScale = 0.15f;
    // 地面のレイヤーマスク
    [SerializeField] private LayerMask GroundLayerMask;
    // 壁のレイヤーマスク
    [SerializeField] private LayerMask WallLayerMask;

    [SerializeField] private Wind1 WindScript;

    // 自身の当たり判定サイズ
    private Vector2 myColliderSize;

    // 以下true条件
    // 地面に設置している
    private bool isGround = true;
    // 壁に触れている
    private bool isWall = false;
    // ジャンプしている
    private bool jump = false;
    // 壁をけっている
    private bool WallKick = false;
    // 右の壁に触れている
    private bool isRightWall = true;

    // 風インターバル
    private float windcount = 0f;
    [SerializeField] private float windinterval = 10f;
    [SerializeField] private float inwind = 3f;

    Vector3 RespawnPos = Vector3.zero;

    int i = 0;
    int j = 0;

    private float[,] jumpvec = { { 1, 0.9f, 0.8f, 0.7f, 0.6f, 0.5f,  0.4f,  0.3f,  0.2f,  0.1f,  0 },       // x変位
                                 { 1, 0.8f, 0.4f, 0.2f, 0.1f,    0, -0.1f, -0.2f, -0.3f, -0.6f, -1 } };     // y変位
    private int[] jumptime =     { 10,  10,    5,    2,    1,   20,    12,     8,     4,     4, -1 };       //それぞれ何フレーム力を加えるか
    

    void Start()
    {
        accelerator = airGravityaccelerator;
        if (RespawnController.instance.RespawnPos == Vector3.zero)
        {
            RespawnController.instance.RespawnPos = this.transform.position;
        }
        else
        {
            this.transform.position = RespawnController.instance.RespawnPos;
        }

        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();

        // 自身のスケールも加味した当たり判定の大きさを取得
        myColliderSize = this.GetComponent<BoxCollider2D>().bounds.size;
    }

    void Update()
    {
        PlayerMove();
    }

    //ゴールに到着
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Respawn")
        {
            RespawnController.instance.RespawnPos = other.transform.position;
            Debug.Log("Respawn更新");
        }
        else if (other.tag == "Goal")
        {
            Debug.Log("ゴール");

            RespawnController.instance.RespawnPos = Vector3.zero;

            int RespawnNum = RespawnController.instance.Respawnobj.Length;

            for (int i = 0; i < RespawnNum; i++)
            {
                Destroy(RespawnController.instance.Respawnobj[i]);
            }

            SceneManager.LoadScene("ClearScene 1");
        }
        else if (other.tag == "dead")
        {
            SceneManager.LoadScene(GameSceneName);
        }
    }

    // Playerの移動を行う
    private void PlayerMove()
    {
        windcount += Time.deltaTime;

        movePos = this.transform.position;

        //左右移動
        float key = 0;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) key = -1;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGround)       // 通常ジャンプ
            {
                jump = true;
                this.animator.SetTrigger("JumpTrigger");
            }
            else if (isWall)    // 壁キック
            {
                jump = true;
                WallKick = true;
                this.animator.SetTrigger("JumpTrigger");
            }
        }

        if (jump)
        {
            // yの変位を加える
            movePos.y += jumpvec[1, i] * JumpForce * JumpSpeed * Time.deltaTime;

            // 壁キックをしているときはxの変位も加える
            if (WallKick)
            {
                key /= 1.5f;
                if (isRightWall)
                {
                    key += -jumpvec[0, i] * 1.5f;
                }
                else
                {
                    key += jumpvec[0, i] * 1.5f;
                }
            }

            if (j < jumptime[i] / JumpSpeed)
            {
                ++j;
            }
            else if (jumptime[i] == -1)         // ジャンプ終了
            {
                WallKick = false;
                JumpFinish();
            }
            else
            {
                j = 0;
                ++i;
            }
        }
        else if (isWall)
        {
            movePos.y -= isWallGravityScale * Time.deltaTime;
        }
        else
        {
            if (!isGround)
            {
                accelerator *= airGravityaccelerator;
            }
            // 重力
            movePos.y -= (GravityScale * Time.deltaTime) / accelerator;
        }

        // xの最終的な変位を加える
        movePos.x += key * WalkForce * Time.deltaTime;

        //動く方向に応じて反転
        if (key != 0)
        {
            if (key > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        // 自身のポジション
        Vector2 myPos = this.transform.position;



        isWall = false;

        // 右の壁判定
        RaycastHit2D hit = Physics2D.Raycast(myPos, Vector3.right, 100, WallLayerMask);

        if (hit.collider && movePos.x + myColliderSize.x / 2 > hit.transform.position.x - hit.collider.bounds.size.x / 2)
        {
            movePos.x = hit.transform.position.x - hit.collider.bounds.size.x / 2 - myColliderSize.x / 2;
            isWall = true;
            isRightWall = true;
            JumpFinish();
        }

        // 左の壁判定
        hit = Physics2D.Raycast(myPos, Vector3.left, 100, WallLayerMask);

        if (hit.collider && movePos.x - myColliderSize.x / 2 < hit.transform.position.x + hit.collider.bounds.size.x / 2)
        {
            movePos.x = hit.transform.position.x + hit.collider.bounds.size.x / 2 + myColliderSize.x / 2;
            isWall = true;
            isRightWall = false;
            JumpFinish();
        }

        // レイの発生地点を足元に変更する。
        myPos.y -= myColliderSize.y / 2 + UnderRayAsist;

        hit = Physics2D.Raycast(myPos, Vector3.down, 100, GroundLayerMask);

        if (hit.collider && movePos.y < hit.transform.position.y + myColliderSize.y / 2 + hit.collider.bounds.size.y / 2)
        {
            accelerator = airGravityaccelerator;
            isGround = true;
            movePos.y = hit.transform.position.y + myColliderSize.y / 2 + hit.collider.bounds.size.y / 2;
            JumpFinish();
        }
        else
        {
            // 空中
            isGround = false;
        }

        // 10より大きく13より小さい
        if (windcount >= windinterval && windcount <= windinterval + inwind)
        {
            movePos += WindScript.WindVector();
            movePos.y += GravityScale * Time.deltaTime / 4;
        }
        else if (windcount > windinterval + inwind)
        {
            windcount = 0;
        }

        // 移動
        this.transform.position = movePos;

        //画面外に出た場合は最初から
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene(GameSceneName);
        }
    }

    private void JumpFinish()
    {
        jump = false;
        WallKick = false;
        i = 0; j = 0;
    }
}
