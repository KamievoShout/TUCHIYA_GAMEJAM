using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // LoadSceneを使うために必要！！
using UnityEngine.UI;
using DG.Tweening;

public class ClearDirector : MonoBehaviour
{
    [SerializeField]
    GameData Data;
    [SerializeField]
    GameObject GameClear;
    [SerializeField]
    GameObject GameOver;
    [SerializeField]
    Text text;
    RectTransform rectTransform;

void Update()
    {
        text.text = "Time: " + Data.TimeLeft;

        if (Data.IsCleared)
        {
            GameClear.SetActive(true);
            GameOver.SetActive(false);
        }
        else
        {
            GameOver.SetActive(true);
            GameClear.SetActive(false);
        }

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("GameScene");
        }
        if(Input.GetKey(KeyCode.T))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}