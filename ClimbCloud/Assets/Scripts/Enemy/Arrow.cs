using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float speed = 50;
    [SerializeField] private float lifeTime = 7;

    private Vector2 dir;
    private float nowTime;

    public void SetDir(Vector2 dir)
    {
        this.dir = dir;
        transform.eulerAngles = new Vector3(0, 0, GetAngle(transform.position, (Vector2)transform.position + dir));
        gameObject.SetActive(true);
    }

    private void Update()
    {
        nowTime += Time.deltaTime;
        transform.position += (Vector3)dir * speed;

        if(nowTime > lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private float GetAngle(Vector2 start, Vector2 target)
    {
        Vector2 dt = target - start;
        float rad = Mathf.Atan2(dt.y, dt.x);
        float degree = rad * Mathf.Rad2Deg;

        return degree;
    }
}
