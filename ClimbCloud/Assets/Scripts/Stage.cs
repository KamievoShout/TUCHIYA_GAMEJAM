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

    
    public Gimmicks gimmicks;


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
    public void UseMoveReverse()
    {
        Debug.Log(gameObject.name + "���]");
        gimmicks.isMoveReverse = true;
    }

    /// <summary>
    /// �o�t��Ԃɂ���
    /// </summary>
    public void UseBuff()
    {
        Debug.Log(gameObject.name + "�o�t");
        gimmicks.isBuff = true;
    }

    /// <summary>
    /// ���t�g���ړ�������
    /// </summary>
    public void UseMoveLift()
    {
        Debug.Log(gameObject.name + "���t�g�ړ�");
        gimmicks.isMoveLift = true;
    }

    /// <summary>
    /// ��ʂ��Â�����
    /// </summary>
    public void UseBlackOut()
    {
        Debug.Log(gameObject.name + "�Ó]");
    }

    /// <summary>
    /// �����o��������
    /// </summary>
    public void UsePillar()
    {
        Debug.Log(gameObject.name + "��");
        gimmicks.isPillar = true;
    }
}
