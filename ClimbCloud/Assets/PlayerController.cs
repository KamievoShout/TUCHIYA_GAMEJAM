using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;      //LoadSceneを使うために必要！！

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;

    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    void Update()
    {
        //ジャンプする
        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
        {
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.AddForce(transform.up *  this.jumpForce);
        }

        //左右移動
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        //プレイヤの速度
        float sppedx = Mathf.Abs(this.rigid2D.velocity.x);

        //スピード制限
        if(sppedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        //動く方向に応じて反転
        if(key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        //プレイヤの速度に応じてアニメーション速度を変える
        if(this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = sppedx / 2.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }

        //画面外に出た場合は最初から
        if(transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    //ゴールに到着
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ゴール");
        //SceneManager.LoadScene("ClearScene");
    }
}
