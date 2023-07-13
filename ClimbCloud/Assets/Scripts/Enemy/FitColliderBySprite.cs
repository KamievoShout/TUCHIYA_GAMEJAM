using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitColliderBySprite : MonoBehaviour
{
    [SerializeField] private SpriteRenderer rend;
    [SerializeField] private BoxCollider2D col;
    [SerializeField] private Vector2 padding;

    private void Update()
    {
        col.size = rend.size + padding;
        Debug.Log(rend.sprite.pivot / rend.sprite.rect.size);
        col.offset = Vector2.Scale(rend.size, new Vector2(0.5f, 0.5f) - (rend.sprite.pivot / rend.sprite.rect.size));
    }
}
