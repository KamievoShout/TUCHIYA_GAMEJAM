using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    // 吹っ飛ばす方向
    private int[] _directions = { 1, -1 };

    [SerializeField, Header("吹っ飛ばす大きさ"), Range(0, 3)]
    private float _addPower;

    private void Update()
    {
        // カメラ外に行ったら自身を消す
        if (!GetComponent<SpriteRenderer>().isVisible)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 当たったら吹っ飛ばす
    /// </summary>
    /// <param name="collision">当たったオブジェクト</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        int direction = _directions[Random.Range(0, 2)];

        rb.AddForce(new Vector2(direction, 0) * _addPower * 100);
    }



    //このオブジェクトがGameViewのみで描画されているか判定用に、
    void OnWillRenderObject()
    {

#if UNITY_EDITOR

        // Debug.LogError("isVisible:::::camera:" + Camera.current.name);

        if (Camera.current.name != "SceneCamera" && Camera.current.name != "Preview Camera")
        {
        }
#endif
    }
}
