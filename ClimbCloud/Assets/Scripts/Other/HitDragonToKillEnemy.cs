using UnityEngine;

public class HitDragonToKillEnemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer target;
    [SerializeField] private BlowAwayEnemy prefab;
    [SerializeField] private float offset = 400;
    [SerializeField] private bool isDestroy = true;

    private Transform spike;

    private void Start()
    {
        spike = GameObject.FindWithTag("Spike").transform;
    }

    private void Update()
    {
        if (spike == null) return;

        if(spike.position.y + offset > transform.position.y)
        {
            BlowAwayEnemy blow = Instantiate(prefab, transform.position, Quaternion.identity);
            blow.Blow(target.sprite);
            if(isDestroy) Destroy(gameObject);
        }
    }
}
