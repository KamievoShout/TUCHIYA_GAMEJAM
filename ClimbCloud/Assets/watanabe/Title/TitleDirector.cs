using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleDirector : MonoBehaviour
{
    [SerializeField] Text TitleText;

    void Start()
    {
        float height = RespawnController.instance.height;
        TitleText.text = "çÇÇ≥ÅF " + height.ToString("F2");
    }
}
