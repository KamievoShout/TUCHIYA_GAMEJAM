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
        // enum��string�ɕϊ�
        animName = playAnim.ToString();

        // ���ݍĐ����̃A�j���[�^�[���ƈ�v���Ȃ���΍Đ�
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName(animName))
        {
            animator.Play(animName);
        }
    }
}
