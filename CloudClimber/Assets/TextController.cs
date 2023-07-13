using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    void Awake()
    {
        transform.localScale = Vector3.zero;
        ShowWindow();
    }

    void ShowWindow()
    {
        transform.DOScale(1f, 1f).SetEase(Ease.OutBounce);
    }
}
