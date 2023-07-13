using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenFloorSystem : MonoBehaviour
{
    [SerializeField, Header("‰ó‚ê‚é‚Ü‚Å‚Ì•b”")]
    private float brakeT = 1;
    [SerializeField, Header("Ä¶‚Ü‚Å‚ÌŠÔ")]
    private float regenerateT = 3;
    private Collider2D col;
    private SpriteRenderer sprite;

    private float braTime;
    private float genTime;

    void Start()
    {
        col = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        braTime += Time.deltaTime;
        Color tmp = sprite.color;
        tmp.a = 1 - braTime / brakeT ;
        sprite.color = tmp;
        if (braTime > brakeT)
        {
            braTime = 0;
            col.enabled = false;
        }
    }


    void Update()
    {
        


        if(!col.enabled)
        {
            genTime += Time.deltaTime;
            Color tmp = sprite.color;
            tmp.a = genTime / regenerateT;
            sprite.color = tmp;
            if (genTime > regenerateT)
            {
                genTime = 0;
                col.enabled = true;
            }
        }
    }
}
