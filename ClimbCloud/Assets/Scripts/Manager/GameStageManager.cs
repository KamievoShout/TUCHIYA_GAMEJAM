using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStageManager : MonoBehaviour
{
    [SerializeField]
    private GameObject leftPlayer;

    [SerializeField]
    private GameObject rightPlayer;

    [SerializeField]
    private Stage leftStage;

    [SerializeField]
    private Stage rightStage;

    [SerializeField]
    private TextMeshProUGUI leftPlayerGoalDistText;

    [SerializeField]
    private TextMeshProUGUI rightPlayerGoalDistText;

    [HideInInspector]
    public float leftPlayerGoalDist;

    [HideInInspector]
    public float rightPlayerGoalDist;

    private Vector2 leftFlagPos;
    private Vector2 rightFlagPos;


    void Start()
    {
        leftFlagPos = leftStage.GetFlagPos();
        rightFlagPos = rightStage.GetFlagPos();
    }

    void Update()
    {
        CalcPlayerGoalDist();
    }

    /// <summary>
    /// ���ꂼ��̃v���C���[�̃S�[���܂ł̋������v�Z����
    /// </summary>
    private void CalcPlayerGoalDist()
    {
        leftPlayerGoalDist = Vector2.Distance(leftPlayer.transform.position, leftFlagPos);
        rightPlayerGoalDist = Vector2.Distance(rightPlayer.transform.position, rightFlagPos);

        leftPlayerGoalDistText.text = Mathf.Floor(leftPlayerGoalDist).ToString();
        rightPlayerGoalDistText.text = Mathf.Floor(rightPlayerGoalDist).ToString();
    }

    /// <summary>
    /// �M�~�b�N�𑊎�ɑ��荞��
    /// </summary>
    /// <param name="playerObj">�M�~�b�N�̎�ɐG�ꂽ�v���C���[</param>
    public void TouchGimmick(GameObject playerObj)
    {
        // TODO:�X�C�b�`�Ŋ撣���ĕ��򂷂�



        if(playerObj.GetComponent<LeftPlayerController>() != null)
        {
            rightStage.UseMoveReverse();
        }

        if(playerObj.GetComponent<RightPlayerController>() != null)
        {
            leftStage.UseMoveReverse();
        }
    }
}
