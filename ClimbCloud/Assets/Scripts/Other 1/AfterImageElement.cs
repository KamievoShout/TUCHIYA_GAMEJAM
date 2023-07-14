using DG.Tweening;
using UnityEngine;

public class AfterImageElement : MonoBehaviour
{
    public void Initalize(float lifeTime, Sprite sprite)
    {
        SpriteRenderer rend = GetComponent<SpriteRenderer>();
        rend.sprite = sprite;

        DOVirtual.Float(0, 1, lifeTime, x =>
        {
            rend.material.SetFloat("_Fade", x);
        }).
        onComplete += () =>
        {
            Destroy(gameObject);
        };
        gameObject.SetActive(true);
    }
}
