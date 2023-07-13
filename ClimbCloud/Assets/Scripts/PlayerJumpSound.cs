using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpSound : MonoBehaviour
{
    /// <summary>
    /// ジャンプ音を出す
    /// </summary>
    public void PlayJumpSound()
    {
        SeManager.Instance.Play("Jump");
    }
}
