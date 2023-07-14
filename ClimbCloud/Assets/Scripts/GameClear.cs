using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameClear : MonoBehaviour
{
    [Tooltip("ゲームスタートのスクリプト")]
    [SerializeField] private GameStart start;

    [Tooltip("フェード用パネル")]
    [SerializeField] private Image FadePanel;

    private bool first;
    private bool clear;
    void Start()
    {
        start.ScriptOff();
        first = false;
        start.enabled = false;
    }

    void Update()
    {
        if (first == false)
        {
            FadePanel.color -= new Color(0, 0, 0, 0.01f);
            if (FadePanel.color == new Color(0, 0, 0, 0))
            {
                start.enabled = true;
                first = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            clear = true;
        }
        if (clear == true)
        {
            StartReset();
        }
    }

    public void StartReset()
    {
        start.ScriptOff();
        FadePanel.color += new Color(0, 0, 0, 0.01f);
        if (FadePanel.color == new Color(0, 0, 0, 1))
        {
            clear = false;
            SceneManager.LoadScene("MachineTest");
        }
    }
}
