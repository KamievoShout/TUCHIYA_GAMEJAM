using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [HideInInspector]
    public float leftPlayerGoalDist;

    [HideInInspector]
    public float rightPlayerGoalDist;

    [SerializeField]
    private Image[] leftPlayerGoalDistImages = new Image[3];

    [SerializeField]
    private Image[] rightPlayerGoalDistImages = new Image[3];

    [SerializeField]
    private Trail leftRrail;

    [SerializeField]
    private Trail rightRrail;

    private const int DIGITS = 3;

    private IntToImage intToImage;

    private Vector2 leftFlagPos;
    private Vector2 rightFlagPos;

    private void Awake()
    {
        Locator<GameStageManager>.Bind(this);
    }

    void Start()
    {
        intToImage = GetComponent<IntToImage>();

        leftFlagPos = leftStage.GetFlagPos();
        rightFlagPos = rightStage.GetFlagPos();

        BgmManager.Instance.Play("Battle");
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

        Sprite[] leftSprites = intToImage.GetSprites((int)Mathf.Floor(leftPlayerGoalDist), DIGITS);
        for (int i = 0; i < leftPlayerGoalDistImages.Length; i++)
        {
            leftPlayerGoalDistImages[i].sprite = leftSprites[i];
        }

        Sprite[] rightSprites = intToImage.GetSprites((int)Mathf.Floor(rightPlayerGoalDist), DIGITS);
        for (int i = 0; i < rightPlayerGoalDistImages.Length; i++)
        {
            rightPlayerGoalDistImages[i].sprite = rightSprites[i];
        }
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
            case GimmickKinds.BlackOut:
                rightStage.UseBlackOut();
                break;
            case GimmickKinds.Pillar:
                rightStage.UsePillar();
                break;
            default:
                break;
        }
        leftRrail.StartTrailing(leftPlayer.transform.position, rightPlayer.transform.position);
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
            case GimmickKinds.BlackOut:
                leftStage.UseBlackOut();
                break;
            case GimmickKinds.Pillar:
                leftStage.UsePillar();
                break;
            default:
                break;
        }
        rightRrail.StartTrailing(rightPlayer.transform.position, leftPlayer.transform.position);
    }
}
