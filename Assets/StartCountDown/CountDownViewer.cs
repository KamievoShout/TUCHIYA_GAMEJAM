using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


class CountDownViewer : MonoBehaviour
{
    [SerializeField]
    CountDown countDown;
    [SerializeField]
    Text text;

    void FixedUpdate()
    {
        text.text = $"{countDown.Count}";

        if (countDown.IsCounting) return;
        gameObject.SetActive(false);
    }
}