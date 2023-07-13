using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class Parachute : MonoBehaviour
{
    [SerializeField] Image inventory;
    [SerializeField] Sprite parachute;
    [SerializeField] float flyJump = 30;

    void OnTriggerEnter2D(Collider2D obj) {
        inventory.enabled = true;
        inventory.sprite = parachute;
        itemController.holdItemCheck = true;
        itemController.stockItem = itemController.item.parachute;
        Destroy(gameObject);
    }

    public void parachuteUseItem(Rigidbody2D rigid2D) {
        //’á‘¬—Ž‰º
        rigid2D.AddForce(Vector2.up * flyJump, ForceMode2D.Impulse);
        rigid2D.drag = 20;
    }
}
