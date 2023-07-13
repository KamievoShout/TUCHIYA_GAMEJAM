using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemController : MonoBehaviour
{
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
    }

    void Update() {
        //�A�C�e���̎g�p
        if (Input.GetKeyDown(KeyCode.Z) && holdItemCheck) {
            holdItemCheck = false;
            rigid2D.velocity = Vector3.zero;
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
