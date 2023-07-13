using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] float rocketJump = 100;

    void OnTriggerEnter2D(Collider2D obj) {
        itemController.holdItemCheck = true;
        itemController.stockItem = itemController.item.rocket;
        Destroy(gameObject);
    }

    public void rocketUseItem(Rigidbody2D rigid2D) {
        //è„è∏
        rigid2D.AddForce(Vector2.up * rocketJump / 4, ForceMode2D.Impulse);
    }
}
