using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    float time = 0;
    public float CurrentTime => time;
    bool isCounting = false;

    public void StartCount()
    {
        isCounting = true;
    }

    void Update()
    {
        if (!isCounting) return;
        time += Time.deltaTime;
    }
}