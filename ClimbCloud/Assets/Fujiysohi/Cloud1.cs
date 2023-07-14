using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud1 : MonoBehaviour
{
    SpriteRenderer sprite;

    bool Playertouch = false;

    [SerializeField] private float ClearTime = 3;

    // Start is called before the first frame update
    void Start()
    {
        sprite = this.GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (Playertouch)
        {
            sprite.color -= new Color(0, 0, 0, 1 / ClearTime * Time.deltaTime);
            if (sprite.color.a <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Playertouch = true;
        }
    }
}
