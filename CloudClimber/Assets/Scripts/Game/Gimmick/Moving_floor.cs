using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_floor : MonoBehaviour
{
    //やりたい事
    //右方向に一定の速度で動かしたい
    //速度はインスペクターで設定したい
    //マップ外を出たら左から出てくる

    //移動床の移動速度
    [SerializeField, PropertyName("移動する床の移動速度")]
    private float movespeed = 3f;


    private void Update()
    {
        //9fはX軸のマップ外を想定
        if (this.transform.position.x < 9f)
        {
            //移動床のpositionがマップ外に行くまで右に移動させる
            this.transform.position += Vector3.left * -movespeed * Time.deltaTime;
        }
        //もし、マップ外を出たら
        else if (this.transform.position.x > 9f)
        {
            //左のマップ外に移動させる
            this.transform.position = new Vector2(-9f, transform.position.y);
        }
    }

    //やりたい事
    //Playerが上に乗ってる時一緒に動かしたい

    //移動する床のコライダーがPlayerに触れた時
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Playerの親を触れた移動床にする
            collision.transform.SetParent(transform);
        }
    }


    // 移動する床のコライダーからPlayerが離れた時
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Playerの親を消す
            collision.transform.SetParent(null);
        }
    }
}
