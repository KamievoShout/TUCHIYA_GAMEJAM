using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSystem : MonoBehaviour
{
    [SerializeField, Header("風の移動速度")]
    float winSpeed;
    [SerializeField, Header("風の移動範囲１，２")]
    float winRan1;
    [SerializeField]
    float winRan2;
    Rigidbody2D rigi;
    private void OnTriggerStay2D(Collider2D other)
    {
        if((rigi = other.gameObject.GetComponent<Rigidbody2D>()) != null)
        {
            rigi.AddForce(rigi.velocity);
        }
    }

    private void FixedUpdate()
    {
        
    }
}
