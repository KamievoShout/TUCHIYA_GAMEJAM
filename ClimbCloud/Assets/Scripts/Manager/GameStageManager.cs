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
    /// それぞれのプレイヤーのゴールまでの距離を計算する
    /// </summary>
    private void CalcPlayerGoalDist()
    {
        leftPlayerGoalDist = Vector2.Distance(leftPlayer.transform.position, leftFlagPos);
        rightPlayerGoalDist = Vector2.Distance(rightPlayer.transform.position, rightFlagPos);

        leftPlayerGoalDistText.text = Mathf.Floor(leftPlayerGoalDist).ToString();
        rightPlayerGoalDistText.text = Mathf.Floor(rightPlayerGoalDist).ToString();
    }

    /// <summary>
    /// ギミックを相手に送り込む
    /// </summary>
    /// <param name="playerObj">ギミックの種に触れたプレイヤー</param>
    public void TouchGimmick(GameObject playerObj)
    {
        // TODO:スイッチで頑張って分岐する



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
