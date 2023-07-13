using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineMove : MonoBehaviour
{
    private Vector3 mousepos; 
    private Vector3 worldpos;
    [Tooltip("移動範囲の制限右")]
    [SerializeField] private float max = 8f;
    [Tooltip("移動範囲の制限左")]
    [SerializeField] private float min = 8f;
    void Start()
    {
        
    }


    void Update()
    {
        //自身の座標を仮置きの変数に保存
        Vector3 pos = gameObject.transform.position;
        //マウスのポジションを取得
        mousepos = Input.mousePosition;
        //スクリーン座標をワールド座標に変換
        worldpos = Camera.main.ScreenToWorldPoint(new Vector3(mousepos.x,0f,0f));
        //ワールド座標のXを仮置きのX座標に設定
        pos.x = worldpos.x;
        //移動範囲を制限
        pos.x = Mathf.Clamp(pos.x, -min, max);
        //自身の座標を仮置きした座標に更新
        gameObject.transform.position = pos;
    }
}
