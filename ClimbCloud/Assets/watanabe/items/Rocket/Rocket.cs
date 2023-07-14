using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    [SerializeField] GameObject useitem;
    [SerializeField] Sprite rocket;
    [SerializeField] Image inventory;
    Rigidbody2D rigid;
    SpriteRenderer spRen;
    bool enTrigger = true;

    void OnTriggerEnter2D(Collider2D obj) {
        if (enTrigger) {
            enTrigger = false;

            //インベントリUI
            inventory.enabled = true;
            inventory.sprite = rocket;

            //手持ちアイテム
            itemController.holdItemCheck = true;
            itemController.stockItem = itemController.item.rocket;

            Destroy(gameObject);
        }
    }

    public void rocketUseItem(Rigidbody2D rigid2D, SpriteRenderer spRen) {
        //アイテム取り出し
        spRen.enabled = true;
        spRen.sprite = rocket;
        this.spRen = spRen;
        rigid = rigid2D;

        //アイテムの使用
        Invoke("rising", 1f) ;
    }

    void rising() {
        spRen.enabled = false;
        enTrigger = true;

        //上昇
        rigid.AddForce(Vector2.up * 30, ForceMode2D.Impulse);
    }
}
