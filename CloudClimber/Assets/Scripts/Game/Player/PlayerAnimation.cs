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

        GroundDetector detector;

        Rigidbody2D rb;

        private void Awake()
        {
            detector = GetComponent<GroundDetector>();
            rb = GetComponent<Rigidbody2D>();

            var mover = GetComponent<PlayerMover>();
            mover.Jumping
            .Subscribe(_ =>
            {
                animator.SetTrigger("JumpTrigger");
            })
            .AddTo(this);

            mover.Speed
                .Where(_ => detector.IsGrounded())
                .Subscribe(value =>
                {
                    animator.SetBool("Walking", value != 0.0f);
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

        private void Update()
        {
            animator.SetBool("Ground", detector.IsGrounded() && rb.velocity.y <= 0.0f);
        }
    }
}