using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Collider2D circleCollider2d;
    [SerializeField] float jumpForce = 680.0f;
    [SerializeField] float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;
    float inputDirKey;                  // 方向キー入力の向き
    bool inputJumpKey;                  // ジャンプキー入力
    [SerializeField] LayerMask lMask;   // レイヤーマスク
    AnimationController animScript;     // アニメーション管理スクリプト

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


#if false
        // ジャンプする
        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
        {
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        // 左右移動
        float key = 0;
        key = Input.GetAxisRaw("Horizontal");

        // プレイヤーの速度
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        // スピード制限
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        // 動く方向に応じて反転
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        // プレイヤーの速度に応じてアニメーション速度を変える
        if (this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = speedx / 2.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }

        // 画面外に出た場合は最初から
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }
#endif
    }

    private void FixedUpdate()
    {
        if (CheckCloud())
        {
            // 地面にいるときの処理
            // ジャンプキーが押されているか
            if (inputJumpKey)
            {
                // 速度初期化
                Vector2 vel = rigid2D.velocity;
                vel.y = 0;
                rigid2D.velocity = vel;

                // ジャンプする
                rigid2D.AddForce(transform.up * this.jumpForce);

                // Jumpアニメーション再生
                animScript.AnimPlay(AnimationController.animationParameter.Jump);
                // サウンド再生

            }
        }

        // 左右キーが押されているか
        if (inputDirKey != 0)
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

            // Walkアニメーション再生
            animScript.AnimPlay(AnimationController.animationParameter.Walk);
        }
        else
        {
            // 押されていないとき
            // Stayアニメーション
            animScript.AnimPlay(AnimationController.animationParameter.Stay);

        }
    }

    // ゴールに到達
    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("ClearScene");
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
        Vector3 rayStart = GetFootPos() * 1.1f;     // レイのスタート
        rayStart.x -= colRadiusX;
        Vector3 rayEnd = GetFootPos() * 1.1f;     // レイの終わり
        rayEnd.x += colRadiusX;

        // レイ射出
        RaycastHit2D rayResult;
        rayResult = Physics2D.Linecast(rayStart, rayEnd, lMask);
        Debug.DrawLine(rayStart, rayEnd);
        if (rayResult.collider != null)
        {
            // レイが雲にヒットしたとき
            isGround = true;
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
}
