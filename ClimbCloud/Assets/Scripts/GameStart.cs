using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    [Tooltip("�^�C�g���I�u�W�F�N�g")]
    [SerializeField] private GameObject Title;
    [Tooltip("�J�E���g�I�u�W�F�N�g1")]
    [SerializeField] private GameObject Count1;
    [Tooltip("�J�E���g�I�u�W�F�N�g2")]
    [SerializeField] private GameObject Count2;
    [Tooltip("�J�E���g�I�u�W�F�N�g3")]
    [SerializeField] private GameObject Count3;
    [Tooltip("�X�^�[�g�I�u�W�F�N�g")]
    [SerializeField] private GameObject StartObj;

    [Tooltip("�X�^�[�g��UI")]
    [SerializeField] private Text StartUI;


    [Tooltip("�^�C�g�����オ��X�s�[�h")]
    [SerializeField] private float TitleFadeSpeed;

    [Tooltip("�^�C�g����������Y���W�̒l")]
    [SerializeField] private float TitleDeth;

    [Tooltip("�J�E���g�_�E���̎���")]
    [SerializeField] private float CountTime = 1;

    [Tooltip("�J�����X�N���[���̃X�N���v�g")]
    [SerializeField] private CameraScroll camer;
    [Tooltip("�������̃X�N���v�g")]
    [SerializeField] private WindGenerator wind;
    [Tooltip("�_�����̃X�N���v�g")]
    [SerializeField] private CloudGenerator cloud;
    [Tooltip("�}�V���̃X�N���v�g")]
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
