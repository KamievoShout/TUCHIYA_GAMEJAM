using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceCloud : MonoBehaviour
{
    Rigidbody2D rb2D;

    public float bouncePow = 10;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
        }
    }

}
