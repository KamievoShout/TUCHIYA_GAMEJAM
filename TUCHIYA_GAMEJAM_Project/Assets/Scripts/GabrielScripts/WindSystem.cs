using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSystem : MonoBehaviour
{
    [SerializeField, Header("•—‚ÌˆÚ“®‘¬“x")]
    float winSpeed;
    [SerializeField, Header("•—‚ÌˆÚ“®”ÍˆÍ‚PC‚Q")]
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
