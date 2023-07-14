using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkSound : MonoBehaviour
{
    /// <summary>
    /// 歩く音を出す
    /// </summary>
    public void PlayWalkSound()
    {
        SeManager.Instance.Play("Move2");
    }
}
