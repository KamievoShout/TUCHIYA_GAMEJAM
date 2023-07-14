using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleDirector : MonoBehaviour
{
    [SerializeField] Text TitleText;

    void Start()
    {
        float height = PlayerHeightUI.height;
        TitleText.text = "çÇÇ≥ÅF " + height.ToString("F2");
    }
}
