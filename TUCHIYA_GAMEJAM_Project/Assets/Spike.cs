using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField]
    private int spikeDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // プレイヤーのダメージの奴出来るまで待機なう
        if(collision.GetComponent<PlayerController>() != null)
        {

        }
    }


}
