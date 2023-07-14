using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cloud : MonoBehaviour
{
    private bool fadeFlg = false;
    private float alpha;
    private float firstalpha;
    private new Renderer renderer;

    private BoxCollider2D box2d;

    private float resPownTime = 1f;
    private float timer = 0;
    private bool resFlg = false;
    // Start is called before the first frame update
    void Start()
    {
        renderer = this.GetComponent<Renderer>();
        alpha = renderer.material.color.a;
        firstalpha = alpha;
        Debug.Log(alpha);
        box2d = this.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (fadeFlg)
        {
            alpha -= 0.01f;
            GetComponent<Renderer>().material.color = new Color(renderer.material.color.r,
                renderer.material.color.g, renderer.material.color.b, alpha);
            if (alpha <= 0)
            {
                fadeFlg = false;
                box2d.enabled = false;
            }
        }
        if (resFlg)
        {
            timer += Time.deltaTime;
            if (timer >= resPownTime)
            {

                alpha += 0.01f;
                GetComponent<Renderer>().material.color = new Color(renderer.material.color.r,
                    renderer.material.color.g, renderer.material.color.b, alpha);
                if (alpha >= 1)
                {
                    timer = 0;
                    box2d.enabled = true;
                }

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.position.y >= this.transform.position.y)
        {
            fadeFlg = true;
            resFlg = false;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            fadeFlg = false;
            resFlg = true;
        }
    }
}
