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
    private GameObject leftStageObj;

    [SerializeField]
    private GameObject rightStageObj;

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
        leftFlagPos = leftStageObj.GetComponent<Stage>().GetFlagPos();
        rightFlagPos = rightStageObj.GetComponent<Stage>().GetFlagPos();
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
}
