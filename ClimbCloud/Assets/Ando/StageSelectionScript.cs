using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectionScript : MonoBehaviour
{
    public string[] stageScene;//�V�[�����̔z��
    public int stageCount;//���I�����Ă��鐔

    public Text textFrame;
    int maxSelect;

    [SerializeField] private Text scoretext;

    void Start()
    {
        maxSelect = stageScene.Length;
        scoretext.text = RespawnController.instance.height.ToString("F2") + "m";
    }

    // Update is called once per frame
    void Update()
    {
        //�X�e�[�W����
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log(stageScene[stageCount] + "��I��");
            SceneManager.LoadScene(stageScene[stageCount]);
        }

        //�X�e�[�W�I�𑀍�
        if (Input.GetKeyDown(KeyCode.D) && stageCount < maxSelect - 1)
        {
            stageCount += 1;
            SoundEffectManager.instance.PlaySoundEffect(0);
        }
        if (Input.GetKeyDown(KeyCode.A) && stageCount > 0)
        {
            stageCount += -1;
            SoundEffectManager.instance.PlaySoundEffect(0);
        }

        textFrame.text = "Stage " + stageCount;
    }
}

