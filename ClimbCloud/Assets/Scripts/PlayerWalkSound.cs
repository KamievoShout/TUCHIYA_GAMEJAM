using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkSound : MonoBehaviour
{
    /// <summary>
    /// ���������o��
    /// </summary>
    public void PlayWalkSound()
    {
        SeManager.Instance.Play("Move2");
    }
}
