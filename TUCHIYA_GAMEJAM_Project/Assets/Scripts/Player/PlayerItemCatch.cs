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
        PlayerCore playerCore;
        private void Start()
        {
            playerCore = GetComponent<PlayerCore>();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            
        }
    }
}
