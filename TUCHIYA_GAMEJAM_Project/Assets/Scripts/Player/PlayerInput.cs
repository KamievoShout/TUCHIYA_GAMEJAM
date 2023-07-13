using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Player
{
    class PlayerInput
    {
        int playerId;
        public Action<float> jumpButtonUp;
        float jumpButtonPushTime;

        public PlayerInput(int _playerId)
        {
            playerId = _playerId;
        }
        /// <summary>
        /// ジャンプボタンを長押しした時間を図る
        /// </summary>
        public void InputUpdate()
        {
            if (playerId == 0 ?
                Input.GetKey(KeyCode.W) : Input.GetKey(KeyCode.UpArrow))
            {
                jumpButtonPushTime += Time.deltaTime;
            }
            if (playerId == 0 ?
                Input.GetKeyUp(KeyCode.W) : Input.GetKeyUp(KeyCode.UpArrow))
            {
                jumpButtonUp?.Invoke(jumpButtonPushTime);
                jumpButtonPushTime = 0;
            }
        }
        public void InputUpdateReset()
        {
            jumpButtonPushTime = 0;
        }
        public float IsPushSideButton()
        {
            if (playerId == Utility.PLAYER1)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    return -1;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else if (playerId == Utility.PLAYER2)
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    return -1;
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            return -114514;
        }
    }
}
