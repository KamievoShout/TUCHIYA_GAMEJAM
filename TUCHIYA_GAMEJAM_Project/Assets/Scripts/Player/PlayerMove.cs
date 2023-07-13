using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Player
{
    [RequireComponent(typeof(Animator), (typeof(Rigidbody2D)))]
    class PlayerMove : MonoBehaviour
    {
        CheckGround checkGround;
        PlayerCore playerCore;
        PlayerInput playerInput;
        Animator animator;
        Rigidbody2D rigidbody2D;

        private void Start()
        {
            playerCore = GetComponent<PlayerCore>();
            playerInput = new PlayerInput(playerCore.PlayerId);
            checkGround = GetComponent<CheckGround>();
            animator = GetComponent<Animator>();
            rigidbody2D = GetComponent<Rigidbody2D>();
            playerInput.jumpButtonUp += Jump;
        }
        private void Update()
        {
            playerInput.InputUpdate();
            if (checkGround.IsGroundCheck())
            {
                //地面にいるときのみジャンプできる
            }
            else
            {
                playerInput.InputUpdateReset();
                //空中にいるときのみ横移動ができる
                SideMove();
            }
        }
        //ジャンプする
        private void Jump(float pushTime)
        {
            if (checkGround.IsGroundCheck())
            {
                rigidbody2D.AddForce(transform.up * pushTime * playerCore.PlayerJumpPower);
            }
        }
        private void SideMove()
        {
            //横移動
            transform.Translate(
                playerInput.IsPushSideButton() * playerCore.PlayerMovePower * Time.deltaTime, 0, 0);
        }
    }
}
