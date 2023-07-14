using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketOperation : MonoBehaviour
{
    public ItemStockController itemStockController;

    public float jumpForce = 5f; // ジャンプ力
    public float jumpTime = 1f; // 上昇時間
    public float maxJumpHeight = 5f; // 最大上昇高さ

    private bool isJumping = false; // ジャンプ中かどうかのフラグ
    private float jumpTimer = 0f; // ジャンプの経過時間
    private float initialY; // ジャンプ開始時のY座標

    private void Start()
    {
        initialY = transform.position.y;
    }

    private void Update()
    {
        if (itemStockController.rocketLaunch == true)
        {
            Jump();
            itemStockController.rocketLaunch = false;
        }

        if (isJumping)
        {
            jumpTimer += Time.deltaTime;

            if (jumpTimer <= jumpTime)
            {
                float normalizedTime = jumpTimer / jumpTime;
                float targetY = initialY + maxJumpHeight;
                float currentY = Mathf.Lerp(initialY, targetY, normalizedTime);
                transform.position = new Vector3(transform.position.x, currentY, transform.position.z);
            }
            else
            {
                StopJump();
            }
        }
    }

    private void Jump()
    {
        isJumping = true;
        jumpTimer = 0f;
        initialY = transform.position.y;
    }

    private void StopJump()
    {
        isJumping = false;
        jumpTimer = 0f;
    }
}
