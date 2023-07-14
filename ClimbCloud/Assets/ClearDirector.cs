using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;      //LoadScene���g�����߂ɕK�v�I�I
using UnityEngine.UI;

public class ClearDirector : MonoBehaviour
{
    [SerializeField] Text heightText;

    void Start() {
        float height = RespawnController.instance.height;
        heightText.text = ($"�����F {height.ToString("F2")}");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
