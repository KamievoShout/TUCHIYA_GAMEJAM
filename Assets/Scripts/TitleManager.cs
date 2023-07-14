using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    private void Start()
    {
        BgmManager.Instance.Play("TitleBgm");
    }
}
