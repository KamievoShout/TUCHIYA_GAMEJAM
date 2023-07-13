using UnityEngine;

namespace PlayerInternal
{
    public static class RigidbodyExtension
    {
        public static void CalculateJumpPower(float time, float height, out float initVelocity, out float gravityScale)
        {
            float tpow2 = time * time;

            // 重力加速度を求める
            float g = -height / ((-tpow2 / 2) + tpow2);

            // 初速を求める
            float vi = -g * time;

            initVelocity = vi;
            gravityScale = ToGravityScale(Mathf.Abs(g));
        }

        public static float ToGravityScale(float gravity)
        {
            float scale = gravity / Physics2D.gravity.magnitude;
            return scale;
        }

        public static void ClearVelocity(this Rigidbody2D rb)
        {
            rb.velocity = Vector2.zero;
        }

        public static void SetVelocityX(this Rigidbody2D rb, float x)
        {
            Vector2 vel = rb.velocity;
            vel.x = x;
            rb.velocity = vel;
        }

        public static void SetVelocityY(this Rigidbody2D rb, float y)
        {
            Vector2 vel = rb.velocity;
            vel.y = y;
            rb.velocity = vel;
        }

        public static void Move(this Rigidbody2D rb, float stickX, float accel, float friction, float maximum)
        {
            float currentSpeed = rb.velocity.x;
            // スティック入力を加味した最大速度制限
            // 入力がない場合は速度制限が0になる
            float maximumSpeed = maximum * Mathf.Abs(stickX);

            // 移動方向への速度
            float moveVecSpeed = rb.velocity.x * Mathf.Sign(stickX);

            // 最大速度を越えている場合減速する
            if (moveVecSpeed > maximumSpeed)
            {
                float nextSpeed = moveVecSpeed - friction;
                if (nextSpeed < maximumSpeed)
                {
                    nextSpeed = maximumSpeed;
                }

                rb.SetVelocityX(nextSpeed * Mathf.Sign(stickX));
                return;
            }

            // 通常
            {
                float next = currentSpeed + accel * stickX;

                if (Mathf.Abs(next) > maximumSpeed)
                {
                    next = maximumSpeed * Mathf.Sign(next);
                }

                rb.SetVelocityX(next);
                return;
            }
        }
    }
}