using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTimer : MonoBehaviour
{
    [SerializeField]
    TimeCounter timeCounter;

    void Start()
    {
        timeCounter.StartCount();
    }
}