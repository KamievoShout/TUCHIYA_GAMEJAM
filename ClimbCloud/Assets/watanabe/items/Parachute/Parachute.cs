using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class Parachute : MonoBehaviour
{
    [SerializeField] GameObject useitem;
    [SerializeField] Image inventory;
    [SerializeField] Sprite parachute;
    Rigidbody2D rigid;
    SpriteRenderer spRen;
    bool enTrigger = true;

    void OnTriggerEnter2D(Collider2D obj) {
        if (enTrigger) {
            enTrigger = false;

            //�C���x���g��UI
            inventory.enabled = true;
            inventory.sprite = parachute;

            //�莝���A�C�e��
            itemController.holdItemCheck = true;
            itemController.stockItem = itemController.item.parachute;

            Destroy(gameObject);
        }
    }

    public void parachuteUseItem(Rigidbody2D rigid2D, SpriteRenderer spRen) {
        //�A�C�e�����o��
        spRen.enabled = true;
        spRen.sprite = parachute;
        this.spRen = spRen;
        rigid = rigid2D;

        //�A�C�e���̎g�p
        Invoke("rising", 1f);
    }


    void rising() {
        spRen.enabled = false;
        enTrigger = true;

        //�ᑬ����
        rigid.gravityScale = -10;
    }
}
