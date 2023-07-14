using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBlock : MonoBehaviour
{
    [SerializeField]
    private ContactFilter2D contactFilter;

    [SerializeField]
    private GameObject effect;

    private Collider2D collider2d;

    void Awake()
    {
        collider2d = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collider2d.IsTouching(collision.collider, contactFilter))
        {
            Destroy(gameObject);

            Destroy(Instantiate(effect, transform.position, Quaternion.identity), 1.0f);
        }
    }
}
