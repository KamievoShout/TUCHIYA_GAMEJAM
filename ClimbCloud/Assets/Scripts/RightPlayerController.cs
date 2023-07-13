using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPlayerController : MonoBehaviour
{

    Rigidbody2D rigid2D;
    Animator animator;

    Vector3 dir = Vector3.zero;

    GameStageManager gameStageManager;

    int key = 0;    //キー入力感知


    float jumpForce = 0f;      //ジャンプ力
    float moveForce = 0f;      //歩行速度

    //通常時
    [Header("通常時の移動速度")]
    [SerializeField] float normalMoveForce = 0;
    [Header("通常時のジャンプ力")]
    [SerializeField] float normalJumpForce = 0;

    //デバフ
    [Header("デバフ時の移動速度")]
    [SerializeField] float debuffMoveForce = 0;
    [Header("デバフ時のジャンプ力")]
    [SerializeField] float debuffJumpForce = 0;


    //操作反転
    [Header("操作反転デバフ")]
    public bool reverse;
    int reversDir = 1;

    //操作超過
    [Header("パワーアップデバフ")]
    public bool powerUpDebuff;

    [SerializeField, Header("デバフ状態を表示する")]
    private DisplayPlayerDebuff displayPlayerDebuff;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        reversDir = 1;
        gameStageManager = Locator<GameStageManager>.GetT();
    }

    // Update is called once per frame
    void Update()
    {
        key = 0;

        //キーの入力感知
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;

        // キー入力があったら歩きアニメーションに移動する
        if (key != 0f)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }

        //操作反転デバフ
        if (reverse)
        {
            displayPlayerDebuff.ShowMoveReverseUi();
            key *= -1;
        }
        else
        {
            displayPlayerDebuff.HideMoveReverseUi();
        }

        //パワーアップデバフ
        if (!powerUpDebuff)
        {
            displayPlayerDebuff.HideBuffUi();
            moveForce = normalMoveForce;
            jumpForce = normalJumpForce;
        }
        else
        {
            displayPlayerDebuff.ShowBuffUi();
            moveForce = debuffMoveForce;
            jumpForce = debuffJumpForce;
        }


        MoveControll(key);      //動きの制御
        ScaleControll(key);     //向きの制御


        if (Input.GetKeyDown(KeyCode.UpArrow) && rigid2D.velocity.y == 0)
        {
            this.animator.SetTrigger("JumpTrigger");
            JumpControll(jumpForce);
        }
    }

    void MoveControll(int key)  //左右移動
    {
        dir = Vector3.zero;
        dir = rigid2D.velocity;
        dir.x = key * moveForce;
        rigid2D.velocity = dir;
    }

    void JumpControll(float jumpForce)  //ジャンプ
    {
        Vector2 vel = rigid2D.velocity;
        vel.y = 0;
        rigid2D.velocity = vel;

        rigid2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void ScaleControll(int key)  //向き調整
    {
        if (key != 0)
        {
            Vector3 scl = transform.localScale;

            scl.x = Mathf.Abs(scl.x) * key;
            transform.localScale = scl;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GimmickSeed gimmickSeed = collision.gameObject.GetComponent<GimmickSeed>();
        GimmickKinds gimmickKind = gimmickSeed.GetGimmickKindType();
        gameStageManager.TouchGimmickRight(this, gimmickKind);
    }
}
