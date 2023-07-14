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

            //�C���x���g��UI
            inventory.enabled = true;
            inventory.sprite = rocket;

            //�莝���A�C�e��
            itemController.holdItemCheck = true;
            itemController.stockItem = itemController.item.rocket;

            Destroy(gameObject);
        }
    }

    public void rocketUseItem(Rigidbody2D rigid2D, SpriteRenderer spRen) {
        //�A�C�e�����o��
        spRen.enabled = true;
        spRen.sprite = rocket;
        this.spRen = spRen;
        rigid = rigid2D;

        //�A�C�e���̎g�p
        Invoke("rising", 1f) ;
    }

    void rising() {
        spRen.enabled = false;
        enTrigger = true;

        //�㏸
        rigid.AddForce(Vector2.up * 30, ForceMode2D.Impulse);
    }
}
