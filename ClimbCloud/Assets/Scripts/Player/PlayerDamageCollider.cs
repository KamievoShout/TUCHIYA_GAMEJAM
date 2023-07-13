using UnityEngine;

public class PlayerDamageCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckPlayer(collision.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CheckPlayer(collision.gameObject);
    }

    private void CheckPlayer(GameObject obj)
    {
        PlayerController controll = obj.GetComponent<PlayerController>();
        if (controll != null)
        {
            controll.Stan();
        }
    }
}
