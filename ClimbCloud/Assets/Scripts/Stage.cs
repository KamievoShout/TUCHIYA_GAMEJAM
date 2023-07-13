using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO:これ切り離す
public struct Gimmicks
{
    public bool isMoveReverse;
    public bool isBuff;
    public bool isMoveLift;
    public bool isBlackOut;
    public bool isPillar;

    // ここクラスを持ってもいいかもしれん
    
    public Gimmicks(bool isMoveReverse, bool isBuff, bool isMoveLift, bool isBlackOut, bool isPillar)
    {
        this.isMoveReverse = isMoveReverse;
        this.isBuff = isBuff;
        this.isMoveLift = isMoveLift;
        this.isBlackOut = isBlackOut;
        this.isPillar = isPillar;
    }
}

public class Stage : MonoBehaviour
{
    [SerializeField]
    private GameObject flagObj;

    [SerializeField]
    private GameObject playerObj;

    [SerializeField]
    private ViewBlackOut blackOut;

    
    public Gimmicks gimmicks;


    void Start()
    {
        gimmicks = new Gimmicks(false, false, false, false, false);
    }

    /// <summary>
    /// 旗の座標を返す
    /// </summary>
    public Vector2 GetFlagPos()
    {
        return flagObj.transform.position;
    }

    /// <summary>
    /// 移動を反転させる
    /// </summary>
    public void UseMoveReverse()
    {
        Debug.Log(gameObject.name + "反転");
        gimmicks.isMoveReverse = true;
    }

    /// <summary>
    /// バフ状態にする
    /// </summary>
    public void UseBuff()
    {
        Debug.Log(gameObject.name + "バフ");
        gimmicks.isBuff = true;
    }

    /// <summary>
    /// リフトを移動させる
    /// </summary>
    public void UseMoveLift()
    {
        Debug.Log(gameObject.name + "リフト移動");
        gimmicks.isMoveLift = true;
    }

    /// <summary>
    /// 画面を暗くする
    /// </summary>
    public void UseBlackOut()
    {
        Debug.Log(gameObject.name + "暗転");
    }

    /// <summary>
    /// 柱を出現させる
    /// </summary>
    public void UsePillar()
    {
        Debug.Log(gameObject.name + "柱");
        gimmicks.isPillar = true;
    }
}
