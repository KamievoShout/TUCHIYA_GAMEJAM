using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    class PlayerMove : MonoBehaviour
    {

        CheckGround checkGround;
        PlayerCore playerCore;
        PlayerInput playerInput;
        Rigidbody2D rigidbody2D;
        SpriteRenderer spriteRenderer;
        private void Start()
        {
            playerCore = GetComponent<PlayerCore>();
            playerInput = new PlayerInput(playerCore.PlayerId);
            checkGround = GetComponent<CheckGround>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            rigidbody2D = GetComponent<Rigidbody2D>();
            playerInput.jumpButtonUp += Jump;
        }
        private void Update()
        {
            playerInput.InputUpdate();
            if (checkGround.IsGroundCheck())
            {
                spriteRenderer.sprite = playerCore.stayImage;
                //地面にいるときのみジャンプできる
                if (playerInput.IsPushJumpButton())
                {
                    spriteRenderer.sprite = playerCore.chargeImage;
                }
            }
            else
            {
                playerInput.InputUpdateReset();
                spriteRenderer.sprite = playerCore.jumpImage;
                //空中にいるときのみ横移動ができる
                SideMove();
            }
        }
        //ジャンプする
        private void Jump(float pushTime)
        {
            if (checkGround.IsGroundCheck())
            {
                rigidbody2D.AddForce(transform.up * ((pushTime * playerCore.PlayerJumpPower) + playerCore.PlayerJumpPower));
            }
        }
        private void SideMove()
        {
            //横移動
            transform.Translate(
                playerInput.IsPushSideButton() * playerCore.PlayerMovePower * Time.deltaTime, 0, 0);
            //反転処理
            transform.localScale = new Vector3(playerInput.IsPushSideButton() != 0 ? playerInput.IsPushSideButton() : transform.localScale.x, 1, 1);
        }
    }
}
