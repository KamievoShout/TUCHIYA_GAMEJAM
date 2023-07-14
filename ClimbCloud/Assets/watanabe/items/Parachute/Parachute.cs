using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parachute : MonoBehaviour
{
    [SerializeField] GameObject useitem;
    [SerializeField] Sprite parachute;
    [SerializeField] Image inventory;
    SpriteRenderer spRen;
    bool enTrigger = true;

    void OnTriggerEnter2D(Collider2D obj) {
        if (enTrigger) {
            enTrigger = false;

            //インベントリUI
            inventory.enabled = true;
            inventory.sprite = parachute;

            //手持ちアイテム
            itemController.holdItemCheck = true;
            itemController.stockItem = itemController.item.parachute;

            Destroy(gameObject);
        }
    }

    public void parachuteUseItem(Rigidbody2D rigid2D, SpriteRenderer spRen) {
        //アイテム取り出し
        spRen.enabled = true;
        spRen.sprite = parachute;
        this.spRen = spRen;

        //アイテムの使用
        Invoke("rising", 1f);
    }


    void rising() {
        spRen.enabled = false;
        enTrigger = true;
    }
}
