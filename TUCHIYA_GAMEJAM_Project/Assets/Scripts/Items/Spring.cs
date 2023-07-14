using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : ItemBase
{
    [SerializeField] Item item;
    [SerializeField] Sprite springSpr;
    [SerializeField] Sprite onSpringSpr;
    SpriteRenderer spriteRenderer;
    public override Item PowerUp()
    {
        spriteRenderer.sprite = onSpringSpr;
        StartCoroutine(SpringUp());
        return item;
    }
    IEnumerator SpringUp()
    {
        yield return new WaitForSeconds(0.8f);
        spriteRenderer.sprite = springSpr;
    }
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
