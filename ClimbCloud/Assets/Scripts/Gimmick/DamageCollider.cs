using UnityEngine;

public class DamageCollider : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		CheckHit(collision.gameObject);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		CheckHit(collision.gameObject);
	}

	private void CheckHit(GameObject obj)
	{
		if (obj.tag == "Player")
		{
			//ƒ_ƒ[ƒWˆ—
		}
	}
}
