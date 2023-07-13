using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPlayerDebuff : MonoBehaviour
{
    [SerializeField]
    private Image moveReverseUi;

    [SerializeField]
    private Image buffUi;

    void Start()
    {
        moveReverseUi.enabled = false;
        buffUi.enabled = false;
    }

    /// <summary>
    /// �ړ����]���UI��\������
    /// </summary>
    public void ShowMoveReverseUi()
    {
        moveReverseUi.enabled = true;
    }

    /// <summary>
    /// �ړ����]���UI���\���ɂ���
    /// </summary>
    public void HideMoveReverseUi()
    {
        moveReverseUi.enabled = false;
    }

    /// <summary>
    /// �o�t���Ui��\������
    /// </summary>
    public void ShowBuffUi()
    {
        buffUi.enabled = true;
    }

    /// <summary>
    /// �o�t���Ui���\���ɂ���
    /// </summary>
    public void HideBuffUi()
    {
        buffUi.enabled = false;
    }

}
