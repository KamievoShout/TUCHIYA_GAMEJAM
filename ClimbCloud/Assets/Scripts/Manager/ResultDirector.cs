using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultDirector : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return))
        {
            FadeManager.Instance.LoadScene("TitleScene", 1.0f);
        }
    }
}
