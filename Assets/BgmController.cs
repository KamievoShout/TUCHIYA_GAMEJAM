using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmController : MonoBehaviour
{
    
    void Start()
    {
        BgmManager.Instance.Play("GameBgm");
    }

    void Update()
    {
        
    }
}
