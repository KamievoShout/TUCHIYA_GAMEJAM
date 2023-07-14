using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text GameOverText;
    public Text GameClearText;
    public Text TimescoreText;

    void Awake()
    {
        //transform.localScale = Vector3.zero;
        ShowWindow();
    }

    void ShowWindow()
    {
        GameOverText.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0),1f).SetEase(Ease.OutBounce);
        GameClearText.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 1f).SetEase(Ease.OutBounce);
        TimescoreText.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, -60), 0.5f).SetDelay(1f);
        transform.DOScale(1f, 1f).SetEase(Ease.OutBounce);
    }
}
