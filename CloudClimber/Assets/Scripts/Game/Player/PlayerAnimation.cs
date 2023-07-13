using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace PlayerInternal
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField]
        Animator animator;

        private void Awake()
        {
            var mover = GetComponent<PlayerMover>();
            mover.Jumping
            .Subscribe(_ =>
            {
                animator.SetTrigger("JumpTrigger");
                animator.speed = 1.0f;
            })
            .AddTo(this);

            mover.Speed
                .Where(_ => animator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Jump")
                .Subscribe(value =>
                {
                    animator.speed = Mathf.Abs(value);
                }).AddTo(this);

            mover.Speed
                .Where(speed => speed != 0.0f)
                .Subscribe(speed =>
                {
                    float rot = speed > 0 ? 0.0f : 180.0f;
                    animator.transform.localEulerAngles = new Vector3(0.0f, rot, 0.0f);
                })
                .AddTo(this);
        }
    }
}