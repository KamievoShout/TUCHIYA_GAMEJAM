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

    private void Awake()
    {
        Locator<GameStageManager>.Bind(this);
    }

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

    public void TouchGimmickLeft(LeftPlayerController leftPlayerController, GimmickKinds gimmickKind)
    {
        switch (gimmickKind)
        {
            case GimmickKinds.MoveReverse:
                rightStage.UseMoveReverseLeft();
                break;
            case GimmickKinds.Buff:
                rightStage.UseBuffLeft();
                break;
            case GimmickKinds.MoveLift:
                rightStage.UseMoveLift();
                break;
            case GimmickKinds.BlackOut:
                rightStage.UseBlackOut();
                break;
            case GimmickKinds.Pillar:
                rightStage.UsePillar();
                break;
            default:
                break;
        }
    }

    public void TouchGimmickRight(RightPlayerController rightPlayerController, GimmickKinds gimmickKind)
    {
        switch (gimmickKind)
        {
            case GimmickKinds.MoveReverse:
                leftStage.UseMoveReverseRight();
                break;
            case GimmickKinds.Buff:
                leftStage.UseBuffRight();
                break;
            case GimmickKinds.MoveLift:
                leftStage.UseMoveLift();
                break;
            case GimmickKinds.BlackOut:
                leftStage.UseBlackOut();
                break;
            case GimmickKinds.Pillar:
                leftStage.UsePillar();
                break;
            default:
                break;
        }
    }
}
