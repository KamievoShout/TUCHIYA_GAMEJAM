using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    [SerializeField] Image inventory;
    [SerializeField] Image useitem;
    [SerializeField] Sprite rocket;
    [SerializeField] float JumpSpeed = 10;
    Rigidbody2D rig;

    private void Start() {
        rig = GameObject.Find("cat").GetComponent<Rigidbody2D>();
    }

    void Update() {
        //rig.velocity -= new Vector2(0, 0.875f);
    }

    void OnTriggerEnter2D(Collider2D obj) {
        inventory.enabled = true;
        inventory.sprite = rocket;
        itemController.holdItemCheck = true;
        itemController.stockItem = itemController.item.rocket;
        Destroy(gameObject);
    }

    public void rocketUseItem(Rigidbody2D rigid2D) {
        rigid2D.AddForce(Vector2.up * JumpSpeed);
    }
}
