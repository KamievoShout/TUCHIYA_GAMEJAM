using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Player
{
    class PlayerItemCatch : MonoBehaviour
    {
        [SerializeField] float springJumpPower;
        
        PlayerCore playerCore;
        Rigidbody2D rigidbody2D;
        private void Start()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            playerCore = GetComponent<PlayerCore>();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<ItemBase>() == null) return;
            switch (collision.GetComponent<ItemBase>().PowerUp())
            {
                case ItemBase.Item.SpeedUpItem:
                    break;
                case ItemBase.Item.DamageUpItem:
                    break;
                case ItemBase.Item.Muteki:
                    break;
                case ItemBase.Item.Heal:
                    break;
                case ItemBase.Item.Jump:
                    rigidbody2D.velocity = Vector2.zero;
                    rigidbody2D.AddForce(transform.up * springJumpPower);
                    break;
                default:
                    break;
            }
        }
    }
}
