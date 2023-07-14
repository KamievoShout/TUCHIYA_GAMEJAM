using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearDirector : MonoBehaviour
{
    private void Start()
    {
        BgmManager.Instance.Play("ClearBGM");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            SceneManager.LoadScene("GameScene");
        }
    }
}