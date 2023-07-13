using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlatformController : MonoBehaviour
{
    Vector2 startPos;
    bool Fall = false;
    float Timer = 0;
    public float ResetTime = 3;
    public float ofset = 0.5f;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (Fall)
        {
            Timer += Time.deltaTime;

            if(Timer > ResetTime)
            {
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                rb.velocity = Vector2.zero;
                rb.isKinematic = true;
                Timer = 0;
                Fall = false;
                transform.position = startPos;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player P))
        {
            Vector3 playerpos = P.transform.position;
            Vector3 selfPos = transform.position;
            if (selfPos.y + ofset < playerpos.y)
            {
                GetComponent<Rigidbody2D>().isKinematic = false;
                Fall = true;
            }
        }
    }
}
