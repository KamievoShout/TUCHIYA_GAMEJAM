using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO:����؂藣��
public struct Gimmicks
{
    public bool isMoveReverse;
    public bool isBuff;
    public bool isMoveLift;
    public bool isBlackOut;
    public bool isPillar;

    // �����N���X�������Ă��������������
    
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

    [SerializeField]
    private CameraShake cameraShake;
    
    
    public Gimmicks gimmicks;

    private float cameraShakeDuration = 0.3f;
    private float cameraShakeMagnitude = 0.1f;


    void Start()
    {
        gimmicks = new Gimmicks(false, false, false, false, false);
    }

    /// <summary>
    /// ���̍��W��Ԃ�
    /// </summary>
    public Vector2 GetFlagPos()
    {
        return flagObj.transform.position;
    }

    /// <summary>
    /// �ړ��𔽓]������
    /// </summary>
    public void UseMoveReverseLeft()
    {
        if (gimmicks.isMoveReverse == true)
        {
            return;
        }
        gimmicks.isMoveReverse = true;
        StartCoroutine(RightRevers());
    }

    private IEnumerator RightRevers()
    {
        cameraShake.Shake(cameraShakeDuration, cameraShakeMagnitude);  // �J������U��������
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
        gimmicks.isMoveReverse = true;
        StartCoroutine(LeftRevers());

    }

    private IEnumerator LeftRevers()
    {
        cameraShake.Shake(cameraShakeDuration, cameraShakeMagnitude);  // �J������U��������
        playerObj.GetComponent<LeftPlayerController>().reverse = true;
        yield return new WaitForSeconds(GimmickStaticData.MOVE_REVERSE_TIME);
        playerObj.GetComponent<LeftPlayerController>().reverse = false;
        gimmicks.isMoveReverse = false;

    }

    /// <summary>
    /// �o�t��Ԃɂ���
    /// </summary>
    public void UseBuffLeft()
    {
        if(gimmicks.isBuff == true)
        {
            return;
        }
        gimmicks.isBuff = true;
        StartCoroutine(BuffRight());
    }

    private IEnumerator BuffRight()
    {
        cameraShake.Shake(cameraShakeDuration, cameraShakeMagnitude);  // �J������U��������
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
        gimmicks.isBuff = true;
        StartCoroutine(BuffLeft());

    }

    private IEnumerator BuffLeft()
    {
        cameraShake.Shake(cameraShakeDuration, cameraShakeMagnitude);  // �J������U��������
        playerObj.GetComponent<LeftPlayerController>().powerUpDebuff = true;
        yield return new WaitForSeconds(GimmickStaticData.BUFF_TIME);
        playerObj.GetComponent<LeftPlayerController>().powerUpDebuff = false;
        gimmicks.isBuff = false;
    }

    /// <summary>
    /// ��ʂ��Â�����
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
        cameraShake.Shake(cameraShakeDuration, cameraShakeMagnitude);  // �J������U��������
        blackOut.StartBlackOut();
        yield return new WaitForSeconds(GimmickStaticData.BLACKOUT_TIME);
        blackOut.QuitBlackOut();
        gimmicks.isBlackOut = false;
    }

    /// <summary>
    /// �����o��������
    /// </summary>
    public void UsePillar()
    {
        cameraShake.Shake(cameraShakeDuration, cameraShakeMagnitude);  // �J������U��������
        gimmicks.isPillar = true;
        fallPillar.GeneratePillar(playerObj.transform.position);
    }
}
