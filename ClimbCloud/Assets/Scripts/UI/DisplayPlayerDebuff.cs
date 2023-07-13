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

    private GameObject rootObj;

    void Start()
    {
        moveReverseUi.enabled = false;
        buffUi.enabled = false;

        rootObj = gameObject.transform.root.gameObject;
    }

    private void Update()
    {
        if (rootObj.transform.localScale.x < 0)
        {
            Vector3 localScale = this.gameObject.transform.localScale;
            localScale.x = -1;
            this.gameObject.transform.localScale = localScale;
        }
        else
        {
            Vector3 localScale = this.gameObject.transform.localScale;
            localScale.x = 1;
            this.gameObject.transform.localScale = localScale;
        }
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
