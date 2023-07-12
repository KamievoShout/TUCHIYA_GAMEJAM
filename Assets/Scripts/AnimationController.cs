using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private string animName;
    private string nowPlayingAnim;

    public enum animationParameter
    {
        Jump,
        Stay,
        Walk,
    }

    public void AnimInit()
    {
        animator       = GetComponent<Animator>();
    }

    public void AnimPlay(animationParameter playAnim)
    {
        // enumをstringに変換
        animName = playAnim.ToString();

        // 現在再生中のアニメーター名を取得
        nowPlayingAnim = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
        if(nowPlayingAnim != animName)
        {
            animator.Play(animName);
        }
    }
}
