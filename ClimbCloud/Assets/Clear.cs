using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "LeftPlayer")
        {
            FadeManager.Instance.LoadScene("ResultScene", 1.0f);
        }
        else if(collision.gameObject.name == "RightPlayer")
        {
            FadeManager.Instance.LoadScene("ResultScene", 1.0f);
        }
    }
}
