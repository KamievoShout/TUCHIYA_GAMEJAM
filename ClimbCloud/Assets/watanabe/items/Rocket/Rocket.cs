using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody2D rigid2D;
    float jumpForce = 680.0f;

    void Start() {
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D obj) {
        Debug.Log(obj.tag);
        if (obj.tag != null) {
            rocketUseItem(obj);
            Destroy(gameObject);
        }
    }

    void rocketUseItem(Collider2D obj) {
        this.rigid2D.AddForce(transform.up * this.jumpForce);
    }
}
