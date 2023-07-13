using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Player
{
    class PlayerDamage:MonoBehaviour
    {
        PlayerCore playerCore;
        private void Start()
        {
            playerCore = GetComponent<PlayerCore>();
        }
        public void Damage(int damage)
        {
            playerCore.PlayerHp -= damage;
        }
    }
}
