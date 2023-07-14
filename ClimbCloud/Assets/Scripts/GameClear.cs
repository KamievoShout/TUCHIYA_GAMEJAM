using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameClear : MonoBehaviour
{
    [Tooltip("�Q�[���X�^�[�g�̃X�N���v�g")]
    [SerializeField] private GameStart start;

    [Tooltip("�t�F�[�h�p�p�l��")]
    [SerializeField] private Image FadePanel;

    [Tooltip("�X�^�[�g��UI")]
    [SerializeField] private GameObject StartUI;

    [Tooltip("�N���A�I�u�W�F�N�g")]
    [SerializeField] private GameObject ClearObj;

    private bool first;
    private bool clear;
    private float time = 0;
    void Start()
    {
        ClearObj.SetActive(false);
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

        time += Time.deltaTime;

        //if (time >= 10)
        //{
        //    start.ScriptOff();
        //    StartUI.SetActive(true);
        //    ClearObj.SetActive(true);
        //    if (Input.anyKeyDown)
        //    {
        //        clear = true;
        //    }
        //}
        //if (clear == true)
        //{
        //    StartUI.SetActive(false);
        //    ClearObj.SetActive(false);
        //    StartReset();
        //}
    }

    public void StartReset()
    {
        FadePanel.color += new Color(0, 0, 0, 0.01f);
        if (FadePanel.color == new Color(0, 0, 0, 1))
        {
            clear = false;
            SceneManager.LoadScene("MachineTest");
        }
    }
}
