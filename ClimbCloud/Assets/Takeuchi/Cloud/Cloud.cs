using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    BoxCollider2D box2D;   
    // Start is called before the first frame update
    void Start()
    {
        box2D = this.GetComponent<BoxCollider2D>();
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {

            //this.transform.position
        }
    }
}
