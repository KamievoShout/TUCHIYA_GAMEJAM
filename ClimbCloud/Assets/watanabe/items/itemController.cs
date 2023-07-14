using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemController : MonoBehaviour
{
    [SerializeField] Image inventory;
    [SerializeField] Rocket rocket;
    [SerializeField] Parachute parachute;
    [SerializeField] GameObject useItem;
    Rigidbody2D rigid2D;
    SpriteRenderer spRen;
    public static bool holdItemCheck;
    public static item stockItem;   //手持ちアイテム

    public enum item {              //アイテムの種類
        rocket,
        parachute
    }

    void Start() {
        this.rigid2D = GetComponent<Rigidbody2D>();
        spRen = useItem.GetComponent<SpriteRenderer>();

        holdItemCheck = false;
        inventory.enabled = false;
    }

    void Update() {
        useItem.transform.position = transform.position + new Vector3(0, 1.5f, 0);

        //アイテムの使用
        if (Input.GetKeyDown(KeyCode.Z) && holdItemCheck) {
            inventory.enabled = false;
            holdItemCheck = false;
            switch (stockItem) {    //使用アイテムチェック
                case item.rocket:
                    rocket.rocketUseItem(rigid2D, spRen);
                    break;
                case item.parachute:
                    parachute.parachuteUseItem(rigid2D, spRen);
                    break;
            }
        }

        if (rigid2D.velocity.y != 0) {
            Invoke("Revelocity", 0.375f);
        }
    }

    void Revelocity() {
        rigid2D.velocity = Vector3.zero;
    }
}
