using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultTimeViewer : MonoBehaviour
{
    [SerializeField]
    TimeCashAsset timeCashAsset;
    [SerializeField]
    Text text;

    void Start()
    {
        text.text = timeCashAsset.GetStringTime();
    }
}