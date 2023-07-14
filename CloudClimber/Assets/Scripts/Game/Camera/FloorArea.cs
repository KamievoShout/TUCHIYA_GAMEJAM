using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FloorArea : MonoBehaviour
{
    [SerializeField, PropertyName("ƒtƒƒA“ž’BŽž‚Ì‰„’·ŽžŠÔ")]
    float addTime = 20.0f;

    [SerializeField]
    private Vector2 size = Vector2.one;

    public Vector2 Size => new Vector2(size.x * transform.lossyScale.x, size.y * transform.lossyScale.y);
    public Vector2 BottomLeft => (Vector2)transform.position - size * 0.5f;
    public Vector2 UpperRight => (Vector2)transform.position + size * 0.5f;

    private BoxCollider2D boxCollider;

    private bool isPassed = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _))
        {
            MessageBroker.Default.Publish(this);

            if (!isPassed)
            {
                isPassed = true;
                MessageBroker.Default.Publish(new AddTime() { time = this.addTime });
            }
        }
    }


#if UNITY_EDITOR
    private void OnValidate()
    {
        if (!boxCollider) boxCollider = GetComponent<BoxCollider2D>();
        if (!boxCollider)
        {
            boxCollider = gameObject.AddComponent<BoxCollider2D>();
            boxCollider.isTrigger = true;
        }
        boxCollider.size = size;
    }
#endif
}
