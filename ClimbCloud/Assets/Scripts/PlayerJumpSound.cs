using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpSound : MonoBehaviour
{
    /// <summary>
    /// ƒWƒƒƒ“ƒv‰¹‚ğo‚·
    /// </summary>
    public void PlayJumpSound()
    {
        SeManager.Instance.Play("Jump");
    }
}
