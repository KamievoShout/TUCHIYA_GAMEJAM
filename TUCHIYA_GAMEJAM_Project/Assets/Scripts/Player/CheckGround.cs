using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Player
{
    [RequireComponent(typeof(BoxCollider2D))]   //BoxColliderがついてないとエラーはくアトリビュート
    class CheckGround : MonoBehaviour
    {
        [SerializeField] float checkLangth;
        [SerializeField] LayerMask checkLayer;
        BoxCollider2D collider2D;
        private void Start()
        {
            collider2D = GetComponent<BoxCollider2D>();
        }
        public bool IsGroundCheck()
        {
            //レイを出して地面判定
            Debug.DrawRay(new Vector2(transform.position.x - collider2D.size.x / 2 + collider2D.offset.x,
                transform.position.y - collider2D.size.y / 2 + collider2D.offset.y) * checkLangth, Vector2.down, Color.red);
            Debug.DrawRay(new Vector2(transform.position.x + collider2D.offset.x,
               transform.position.y - collider2D.size.y / 2 + collider2D.offset.y) * checkLangth, Vector2.down, Color.red);
            Debug.DrawRay(new Vector2(transform.position.x + collider2D.size.x / 2 + collider2D.offset.x,
               transform.position.y - collider2D.size.y / 2 + collider2D.offset.y) * checkLangth, Vector2.down, Color.red);

            var hit1 = Physics2D.Raycast(new Vector2(transform.position.x - collider2D.size.x / 2 + collider2D.offset.x,
                transform.position.y - collider2D.size.y / 2 + collider2D.offset.y), Vector2.down, checkLangth, checkLayer).collider;
            var hit2 = Physics2D.Raycast(new Vector2(transform.position.x + collider2D.offset.x,
               transform.position.y - collider2D.size.y / 2 + collider2D.offset.y), Vector2.down, checkLangth, checkLayer / 2).collider;
            var hit3 = Physics2D.Raycast(new Vector2(transform.position.x + collider2D.size.x / 2 + collider2D.offset.x,
               transform.position.y - collider2D.size.y / 2 + collider2D.offset.y), Vector2.down, checkLangth, checkLayer / 2).collider;

            return hit1 != null || hit2 != null || hit3 != null;
        }
    }
}
