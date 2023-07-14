using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    [Tooltip("タイトルオブジェクト")]
    [SerializeField] private GameObject Title;
    [Tooltip("カウントオブジェクト1")]
    [SerializeField] private GameObject Count1;
    [Tooltip("カウントオブジェクト2")]
    [SerializeField] private GameObject Count2;
    [Tooltip("カウントオブジェクト3")]
    [SerializeField] private GameObject Count3;
    [Tooltip("スタートオブジェクト")]
    [SerializeField] private GameObject StartObj;

    [Tooltip("スタートのUI")]
    [SerializeField] private Text StartUI;


    [Tooltip("タイトルが上がるスピード")]
    [SerializeField] private float TitleFadeSpeed;

    [Tooltip("タイトルが消えるY座標の値")]
    [SerializeField] private float TitleDeth;

    [Tooltip("カウントダウンの時間")]
    [SerializeField] private float CountTime = 1;

    [Tooltip("カメラスクロールのスクリプト")]
    [SerializeField] private CameraScroll camer;
    [Tooltip("風生成のスクリプト")]
    [SerializeField] private WindGenerator wind;
    [Tooltip("雲生成のスクリプト")]
    [SerializeField] private CloudGenerator cloud;
    [Tooltip("マシンのスクリプト")]
    [SerializeField] private MachineMove machine;

    private bool TitleFade;
    private bool CountDown;
    private float time = 0;
    void Start()
    {
        ScriptOff();
        TitleFade = false;
        CountDown = false;
        Count1.SetActive(false);
        Count2.SetActive(false);
        Count3.SetActive(false);
        time = 0;
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            Destroy(StartUI);
            TitleFade = true;
        }
        if (TitleFade == true)
        {
            if (Title.activeSelf)
            {
                Vector3 pos = Title.transform.position;
                pos.y += TitleFadeSpeed * Time.deltaTime;
                Title.transform.position = pos;
                if (Title.transform.position.y >= TitleDeth)
                {
                    Title.SetActive(false);
                }
            }
            else
            {
                CountDown = true;
                TitleFade = false;
            }
        }
        if (CountDown == true)
        {
            time += Time.deltaTime;
            if (time >= CountTime && Count3.activeSelf)
            {
                Count3.SetActive(false);
                Count2.SetActive(true);
                Debug.Log("2");
                time = 0;
            }
            else if (time >= CountTime && Count2.activeSelf)
            {
                Count2.SetActive(false);
                Count1.SetActive(true);
                Debug.Log("1");
                time = 0;
            }
            else if (time >= CountTime && Count1.activeSelf)
            {
                Count1.SetActive(false);
                StartObj.SetActive(true);
                CountDown = false;
                ScriptOn();
                Debug.Log("0");
            }
            else if (time >= CountTime)
            {
                Count3.SetActive(true);
                Debug.Log("3");
                time = 0;
            }
        }

    }

    public void ScriptOff()
    {
        camer.enabled = false;
        wind.enabled = false;
        cloud.enabled = false;
        machine.enabled = false;
    }
    public void ScriptOn()
    {
        camer.enabled = true;
        wind.enabled = true;
        cloud.enabled = true;
        machine.enabled = true;
        gameObject.GetComponent<GameStart>().enabled = false;
    }
}
