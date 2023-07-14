using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    void Start()
    {
        
    }

    /// <summary>
    /// ResultScene‚ÉˆÚ“®‚·‚é
    /// </summary>
    public void TransResultScene(bool isLeft)
    {
        if(isLeft)
        {
            FadeManager.Instance.LoadScene("LeftPlayerWinScene", 1.0f);
        }
        else
        {
            FadeManager.Instance.LoadScene("RightPlayerWInScene", 1.0f);
        }
    }
}
