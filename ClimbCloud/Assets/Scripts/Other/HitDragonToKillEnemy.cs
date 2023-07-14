using UnityEngine;
using Utility;
using Utility.Audio;

public class HitDragonToKillEnemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer target;
    [SerializeField] private BlowAwayEnemy prefab;
    [SerializeField] private bool isDestroy = true;

    private Transform spike;

    private void Start()
    {
        spike = GameObject.FindWithTag("Spike").transform;
    }

    private void Update()
    {
        if (spike == null) return;

        if(spike.position.y > transform.position.y)
        {
            BlowAwayEnemy blow = Instantiate(prefab, transform.position, Quaternion.identity);
            blow.Blow(target.sprite);
            if (isDestroy)
            {
                Locator<IPlayAudio>.Resolve().PlaySE("DeadEnemy");
                Destroy(gameObject);
            }
        }
    }
}
