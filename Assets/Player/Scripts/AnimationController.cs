using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private string animName;
    private string nowPlayingAnim;
    public animationParameter animParameter;

    public enum animationParameter
    {
        Jump,
        Stay,
        Walk,
        DoubleJump
    }

    public void AnimInit()
    {
        animator = GetComponent<Animator>();
    }

    public void AnimPlay(animationParameter playAnim)
    {
        // enumをstringに変換
        animName = playAnim.ToString();

        // 現在再生中のアニメーター名と一致しなければ再生
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName(animName))
        {
            animator.Play(animName);
        }
    }
}
