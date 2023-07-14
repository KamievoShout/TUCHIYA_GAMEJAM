using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationQuit : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("TitleScene");
#else
        Application.Quit();
#endif
        }
    }
}
