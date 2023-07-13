using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeViewer : MonoBehaviour
{
    [SerializeField]
    TimeCounter timeCounter;
    [SerializeField]
    Text text;

    void FixedUpdate()
    {
        text.text = $"Time:{timeCounter.CurrentTime:000.##}";
    }
}