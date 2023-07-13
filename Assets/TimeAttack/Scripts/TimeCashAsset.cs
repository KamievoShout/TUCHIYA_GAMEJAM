using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TimeCashAsset")]
public class TimeCashAsset : ScriptableObject
{
    float time;

    public void SetTime(float time)
    {
        this.time = time;
    }

    public string GetStringTime()
    {
        return $"Time:{time:000.##}";
    }
}