using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

enum jumpState
{
    notJumping,
    singleJump,
    doubleJump,
    falling
}

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Collider2D circleCollider2d;
    [SerializeField] float jumpForce = 680.0f;
    [SerializeField] float walkForce = 30.0f;
    float inputDirKey;                  // 方向キー入力の向き
    bool inputJumpKey;                  // ジャンプキー入力
    [SerializeField] LayerMask lMask;   // レイヤーマスク
    AnimationController animScript;     // アニメーション管理スクリプト
    Vector3 jumpedPos;                  // ジャンプした位置
    jumpState nowJumpState;             // ダブルジャンプが可能か
    [SerializeField]
    Vector2 doubleJumpForce =           // ダブルジャンプの力
        new Vector2(10f, 4f);
    public bool isGoal = false;         // ゴールしたか
    bool isPlaySE;                      // 雲のSEを再生できるか

    void Start()
    {
        Application.targetFrameRate = 30;
        circleCollider2d = GetComponent<Collider2D>();
        this.rigid2D = GetComponent<Rigidbody2D>();
        animScript = GetComponent<AnimationController>();

        animScript.AnimInit();
    }

    void Update()
    {
        // 方向キーの入力取得
        inputDirKey = 0;
        inputDirKey = Input.GetAxisRaw("Horizontal");

        // ジャンプキーの入力取得
        inputJumpKey = Input.GetButtonDown("Jump");

    }

    private void FixedUpdate()
    {
        // 2段ジャンプを有効化
        if (CheckCloud()) nowJumpState = jumpState.notJumping;
        else isPlaySE = true;

        if (inputJumpKey && nowJumpState != jumpState.falling)
        {
            // 速度初期化
            Vector2 vel = rigid2D.velocity;
            vel.y = 0;
            rigid2D.velocity = vel;

            // サウンド再生
            //SeManager.Instance.Play("Jump");

            // 地面にいるときの処理
            // ジャンプキーが押されているか
            if (CheckCloud())
            {
                // ジャンプする
                rigid2D.AddForce(transform.up * this.jumpForce);
                nowJumpState = jumpState.singleJump;
                // Jumpアニメーション再生
                animScript.AnimPlay(AnimationController.animationParameter.Jump);

                // ジャンプした位置取得
                jumpedPos = transform.position;

                inputJumpKey = false;
            }
            else if (nowJumpState != jumpState.doubleJump)
            {
                // 向いている方向へダブルジャンプ
                doubleJumpForce.x = Mathf.Abs(doubleJumpForce.x) * transform.localScale.x;

                rigid2D.AddForce(doubleJumpForce);
                nowJumpState = jumpState.doubleJump;

                // DoubleJumpアニメーション再生
                animScript.AnimPlay(AnimationController.animationParameter.DoubleJump);

                inputJumpKey = false;
            }
        }

        // ダブルジャンプしたかつ位置がとんだ場所より下の時
        if(nowJumpState == jumpState.doubleJump && transform.position.y < jumpedPos.y)
        {
            nowJumpState = jumpState.falling;
            // Jumpアニメーション再生
            animScript.AnimPlay(AnimationController.animationParameter.Jump);
        }

        // 左右キーが押されているか かつダブルジャンプをしていない
        if (inputDirKey != 0 && nowJumpState != jumpState.doubleJump)
        {
            // 入力方向へ移動させる
            Vector2 position = rigid2D.velocity;
            position.x = walkForce * inputDirKey;
            rigid2D.velocity = position;

            // 進行方向を向く
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x);       // 実数化
            scale.x *= inputDirKey;
            transform.localScale = scale;
            if (CheckCloud())
            {
                // Walkアニメーション再生
                animScript.AnimPlay(AnimationController.animationParameter.Walk);
            }
        }
        else if (CheckCloud())
        {
            // 押されていないとき
            // Stayアニメーション
            animScript.AnimPlay(AnimationController.animationParameter.Stay);
        }
    }

    // ゴールに到達
    void OnTriggerEnter2D(Collider2D other)
    {
        isGoal = true;
        SceneManager.LoadScene("ClearScene");
        SeManager.Instance.Play("Goal");
    }

    /// <summary>
    /// 雲に当たったか
    /// </summary>
    /// <returns>[bool] 雲の上にいるか</returns>
    bool CheckCloud()
    {
        // 接地判定リセット
        bool isGround = false;
        float colRadiusX = circleCollider2d.bounds.extents.x;

        // レイの長さ指定
        Vector3 rayStart = GetFootPos();     // レイのスタート
        rayStart.x -= colRadiusX;
        rayStart.y -= 0.05f;
        Vector3 rayEnd = GetFootPos();     // レイの終わり
        rayEnd.x += colRadiusX;
        rayEnd.y -= 0.05f;

        // レイ射出
        RaycastHit2D rayResult;
        rayResult = Physics2D.Linecast(rayStart, rayEnd, lMask);
        Debug.DrawLine(rayStart, rayEnd);
        if (rayResult.collider != null)
        {
            // レイが雲にヒットしたとき
            isGround = true;
            if(isPlaySE) CloudSE(rayResult.collider.tag);
        }

        return isGround;
    }

    /// <summary>
    /// 足元の座標を取得
    /// </summary>
    /// <returns>[Vector3] 足元の座標</returns>
    Vector3 GetFootPos()
    {
        // cycleコライダーの一番下の座標を計算で取得
        Vector3 footPos = circleCollider2d.bounds.center;
        float colRadiusY = circleCollider2d.bounds.extents.y;
        footPos.y -= colRadiusY;

        return footPos;
    }

    // 雲SE
    void CloudSE(string tag)
    {
        // 跳ねる雲
        if(tag == "Bounce")
        {
            //SeManager.Instance.Play("BounceCloud");
        }

        // 滑る雲
        if(tag == "Slip")
        {
            //SeManager.Instance.Play("SlipCloud");
        }

        isPlaySE = false;
    }

    // 画面外に出た時に反対側へ
    private void OnBecameInvisible()
    {
        Vector3 pos = transform.position;
        pos.x *= -1;
        transform.position = pos;
    }
}
