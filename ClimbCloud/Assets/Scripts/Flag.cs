using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    void Start()
    {
        
    }

    /// <summary>
    /// ResultSceneに移動する
    /// </summary>
    public void TransResultScene(bool isLeft)
    {
        FadeManager.Instance.LoadScene("ResultScene", 1.0f);
    }
}
