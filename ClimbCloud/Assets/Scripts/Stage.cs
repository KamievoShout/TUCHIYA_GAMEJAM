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

    [SerializeField]
    private FallPillar fallPillar;
    
    
    
    
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
    public void UseMoveReverseLeft()
    {
        if (gimmicks.isMoveReverse == true)
        {
            return;
        }
        Debug.Log(gameObject.name + "反転");
        gimmicks.isMoveReverse = true;
        StartCoroutine(RightRevers());
    }

    private IEnumerator RightRevers()
    {
        playerObj.GetComponent<RightPlayerController>().reverse = true;
        yield return new WaitForSeconds(GimmickStaticData.MOVE_REVERSE_TIME);
        playerObj.GetComponent<RightPlayerController>().reverse = false;
        gimmicks.isMoveReverse = false;

    }

    public void UseMoveReverseRight()
    {
        if (gimmicks.isMoveReverse == true)
        {
            return;
        }
        Debug.Log(gameObject.name + "反転");
        gimmicks.isMoveReverse = true;
        StartCoroutine(LeftRevers());

    }

    private IEnumerator LeftRevers()
    {
        playerObj.GetComponent<LeftPlayerController>().reverse = true;
        yield return new WaitForSeconds(GimmickStaticData.MOVE_REVERSE_TIME);
        playerObj.GetComponent<LeftPlayerController>().reverse = false;
        gimmicks.isMoveReverse = false;

    }

    /// <summary>
    /// バフ状態にする
    /// </summary>
    public void UseBuffLeft()
    {
        if(gimmicks.isBuff == true)
        {
            return;
        }
        Debug.Log(gameObject.name + "バフ");
        gimmicks.isBuff = true;
        StartCoroutine(BuffRight());
    }

    private IEnumerator BuffRight()
    {
        playerObj.GetComponent<RightPlayerController>().powerUpDebuff = true;
        yield return new WaitForSeconds(GimmickStaticData.BUFF_TIME);
        playerObj.GetComponent<RightPlayerController>().powerUpDebuff = false;
        gimmicks.isBuff = false;
    }

    public void UseBuffRight()
    {
        if (gimmicks.isBuff == true)
        {
            return;
        }
        Debug.Log(gameObject.name + "バフ");
        gimmicks.isBuff = true;
        StartCoroutine(BuffLeft());

    }

    private IEnumerator BuffLeft()
    {
        playerObj.GetComponent<LeftPlayerController>().powerUpDebuff = true;
        yield return new WaitForSeconds(GimmickStaticData.BUFF_TIME);
        playerObj.GetComponent<LeftPlayerController>().powerUpDebuff = false;
        gimmicks.isBuff = false;
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
        if(gimmicks.isBlackOut == true)
        {
            return;
        }

        gimmicks.isBlackOut = true;
        StartCoroutine(BlackOut());
    }

    private IEnumerator BlackOut()
    {
        blackOut.StartBlackOut();
        yield return new WaitForSeconds(GimmickStaticData.BLACKOUT_TIME);
        blackOut.QuitBlackOut();
        gimmicks.isBlackOut = false;
    }

    /// <summary>
    /// 柱を出現させる
    /// </summary>
    public void UsePillar()
    {
        Debug.Log(gameObject.name + "柱");
        gimmicks.isPillar = true;
        fallPillar.GeneratePillar(playerObj.transform.position);
    }
}
