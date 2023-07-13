using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleDirector : MonoBehaviour
{
    void Start()
    {
        BgmManager.Instance.Play("Title");
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            FadeManager.Instance.LoadScene("Kato_Main", 1.0f);
        }
    }
}
