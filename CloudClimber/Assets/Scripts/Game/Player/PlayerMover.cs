using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEditorInternal;
using UnityEngine;

namespace PlayerInternal
{
    [RequireComponent(typeof(Rigidbody2D), typeof(GroundDetector))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField, PropertyName("地上の最大速度")]
        private float groundSpeedMax = 3.0f;

        [SerializeField, PropertyName("地上の加速度")]
        private float groundAccel = 6.0f;

        [SerializeField, PropertyName("空中の最大速度")]
        private float airSpeedMax = 1.0f;

        [SerializeField, PropertyName("空中の加速度")]
        private float airAccel = 0.4f;

        [SerializeField, PropertyName("ジャンプ高度")]
        private float jumpHeight = 3.0f;

        [SerializeField, PropertyName("上昇にかかる時間")]
        private float jumpDuration = 0.8f;


        [SerializeField, PropertyName("ノックバックの強さ")]
        private float knockbackPower = 4.0f;

        [SerializeField, PropertyName("ノックバック時の高さ")]
        private float knockbackHeight = 0.8f;

        [SerializeField, PropertyName("ノックバックのスタン時間")]
        private float knockbackStanDuration = 0.8f;

        private Rigidbody2D rb;
        private GroundDetector groundDetector;

        private float defaultGravityScale = 1.0f;

        private Coroutine gravityHandle;
        private Coroutine knockbackHandle;

        private Subject<Unit> jumpingSubject = new Subject<Unit>();
        public IObservable<Unit> Jumping => jumpingSubject;

        private FloatReactiveProperty currentSpeed = new FloatReactiveProperty();
        public IReadOnlyReactiveProperty<float> Speed => currentSpeed;

        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            defaultGravityScale = rb.gravityScale;

            groundDetector = GetComponent<GroundDetector>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)
                && groundDetector.IsGrounded())
            {
                Jump(jumpHeight);
            }
        }

        private void FixedUpdate()
        {
            if (groundDetector.IsGrounded())
            {
                Move(groundSpeedMax, groundAccel);
            }
            else
            {
                Move(airSpeedMax, airAccel);
            }
        }

        private void Move(float max, float accel)
        {
            rb.Move(Input.GetAxisRaw("Horizontal"), accel, accel, max);

            currentSpeed.Value = rb.velocity.x / groundSpeedMax;
        }

        public void Jump(float height)
        {
            Jump(height, jumpDuration);
        }

        public void Jump(float height, float duration)
        {
            RigidbodyExtension.CalculateJumpPower(duration, height, out float vel, out float gravity);

            rb.gravityScale = gravity;
            rb.SetVelocityY(vel);

            if (gravityHandle != null) StopCoroutine(gravityHandle);

            gravityHandle = StartCoroutine(GravityHandle());

            jumpingSubject.OnNext(Unit.Default);
        }

        private IEnumerator GravityHandle()
        {
            yield return new WaitUntil(() => rb.velocity.y <= 0.0f);
            rb.gravityScale = defaultGravityScale;
        }

        public void Stop()
        {
            this.enabled = false;
            rb.ClearVelocity();
        }

        public void Knockback(float dir)
        {
            rb.SetVelocityX(knockbackPower * Mathf.Sign(dir));
            Jump(knockbackHeight, knockbackStanDuration * 0.5f);

            if (knockbackHandle != null) StopCoroutine(knockbackHandle);

            knockbackHandle = StartCoroutine(KnockbackHandle());
        }

        private IEnumerator KnockbackHandle()
        {
            this.enabled = false;
            yield return new WaitForSeconds(knockbackStanDuration);
            this.enabled = true;
        }
    }
}