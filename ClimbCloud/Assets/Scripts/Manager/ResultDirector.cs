using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultDirector : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FadeManager.Instance.LoadScene("TitleScene", 1.0f);
        }
    }
}
