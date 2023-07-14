using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketOperation : MonoBehaviour
{
    public ItemStockController itemStockController;

    public float jumpForce = 5f; // �W�����v��
    public float jumpTime = 1f; // �㏸����
    public float maxJumpHeight = 5f; // �ő�㏸����

    private bool isJumping = false; // �W�����v�����ǂ����̃t���O
    private float jumpTimer = 0f; // �W�����v�̌o�ߎ���
    private float initialY; // �W�����v�J�n����Y���W

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
