using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpSound : MonoBehaviour
{
    /// <summary>
    /// �W�����v�����o��
    /// </summary>
    public void PlayJumpSound()
    {
        SeManager.Instance.Play("Jump");
    }
}
