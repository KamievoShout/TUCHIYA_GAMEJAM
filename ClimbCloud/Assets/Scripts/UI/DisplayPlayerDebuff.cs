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
    /// 移動反転状態UIを表示する
    /// </summary>
    public void ShowMoveReverseUi()
    {
        moveReverseUi.enabled = true;
    }

    /// <summary>
    /// 移動反転状態UIを非表示にする
    /// </summary>
    public void HideMoveReverseUi()
    {
        moveReverseUi.enabled = false;
    }

    /// <summary>
    /// バフ状態Uiを表示する
    /// </summary>
    public void ShowBuffUi()
    {
        buffUi.enabled = true;
    }

    /// <summary>
    /// バフ状態Uiを非表示にする
    /// </summary>
    public void HideBuffUi()
    {
        buffUi.enabled = false;
    }

}
