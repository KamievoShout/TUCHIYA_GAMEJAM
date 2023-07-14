using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkSound : MonoBehaviour
{
    /// <summary>
    /// ï‡Ç≠âπÇèoÇ∑
    /// </summary>
    public void PlayWalkSound()
    {
        SeManager.Instance.Play("Move2");
    }
}
