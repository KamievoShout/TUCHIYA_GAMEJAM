using DG.Tweening;
using UnityEngine;

public class BlowAwayEnemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer rend;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float blowSpeed = 100;
    [SerializeField] private float rotate = 100;
    [SerializeField] private float lifeTime = 8;
    [SerializeField] private float offsetX = 0.2f;

    public void Blow(Sprite sprite)
    {
        rend.sprite = sprite;
        rb.AddForce(new Vector2(Random.Range(-offsetX, offsetX), 1) * blowSpeed, ForceMode2D.Impulse);
        rb.AddTorque(Random.Range(-rotate, rotate), ForceMode2D.Impulse);
        DOVirtual.DelayedCall(lifeTime, () => Destroy(gameObject));
    }
}
