using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player
{
    public class PlayerCore : MonoBehaviour
    {
        [SerializeField] private int playerId;
        [SerializeField] private int hp;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpPower;
        public int PlayerId { get { return playerId; } }
        public float PlayerJumpPower { get { return jumpPower; } }
        public float PlayerMovePower { get { return moveSpeed; } }
        public int PlayerHp { get { return hp; } set { hp = value; } }
    }
}
