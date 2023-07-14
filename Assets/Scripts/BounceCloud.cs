using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceCloud : MonoBehaviour
{
    [SerializeField] float bouncePow = 20;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log(collision.gameObject);


            Vector3 vel = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            vel.y = bouncePow;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = vel;
        }
    }

}
