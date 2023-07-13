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
    public static item stockItem;   //�莝���A�C�e��

    public enum item {              //�A�C�e���̎��
        rocket,
        parachute
    }

    void Start() {
        this.rigid2D = GetComponent<Rigidbody2D>();
        holdItemCheck = false;
        inventory.enabled = false;
    }

    void Update() {
        //�A�C�e���̎g�p
        if (Input.GetKeyDown(KeyCode.Z) && holdItemCheck) {
            inventory.enabled = false;
            holdItemCheck = false;
            switch (stockItem) {    //�g�p�A�C�e���`�F�b�N
                case item.rocket:
                    rocket.rocketUseItem(rigid2D);
                    break;
                case item.parachute:
                    parachute.parachuteUseItem(rigid2D);
                    break;
            }
        }

        //�n�ʂɒ��n����ƃp���V���[�g�̌��ʂ�����
        if(this.rigid2D.velocity.y == 0) {
            rigid2D.drag = 0;
        }
    }
}
