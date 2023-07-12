using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPlayerController : MonoBehaviour
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
        int key = 0;
        if (Input.GetKey(KeyCode.A)) key = -1;
        if (Input.GetKey(KeyCode.D)) key = 1;

        MoveControll(key);      //向きの制御
        ScaleControll(key);     //動きの制御

        if (Input.GetKeyDown(KeyCode.W))
        {
            this.animator.SetTrigger("JumpTrigger");
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
}
