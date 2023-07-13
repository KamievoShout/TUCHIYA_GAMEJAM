using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemController : MonoBehaviour
{
    [SerializeField] Image inventory;
    [SerializeField] Rocket rocket;
    [SerializeField] Parachute parachute;
    Rigidbody2D rigid2D;
    public static bool holdItemCheck;
    public static item stockItem;   //手持ちアイテム

    public enum item {              //アイテムの種類
        rocket,
        parachute
    }

    void Start() {
        this.rigid2D = GetComponent<Rigidbody2D>();
        holdItemCheck = false;
        inventory.enabled = false;
    }

    void Update() {
        //アイテムの使用
        if (Input.GetKeyDown(KeyCode.Z) && holdItemCheck) {
            inventory.enabled = false;
            holdItemCheck = false;
            switch (stockItem) {    //使用アイテムチェック
                case item.rocket:
                    rocket.rocketUseItem(rigid2D);
                    break;
                case item.parachute:
                    parachute.parachuteUseItem(rigid2D);
                    break;
            }
        }

        //地面に着地するとパラシュートの効果を消す
        if(this.rigid2D.velocity.y == 0) {
            rigid2D.drag = 0;
        }
    }
}
