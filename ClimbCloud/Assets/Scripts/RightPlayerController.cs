using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPlayerController : MonoBehaviour
{

    Rigidbody2D rigid2D;
    Animator animator;

    Vector3 dir = Vector3.zero;

    GameStageManager gameStageManager;

    int key = 0;    //�L�[���͊��m


    float jumpForce = 0f;      //�W�����v��
    float moveForce = 0f;      //���s���x

    //�ʏ펞
    [Header("�ʏ펞�̈ړ����x")]
    [SerializeField] float normalMoveForce = 0;
    [Header("�ʏ펞�̃W�����v��")]
    [SerializeField] float normalJumpForce = 0;

    //�f�o�t
    [Header("�f�o�t���̈ړ����x")]
    [SerializeField] float debuffMoveForce = 0;
    [Header("�f�o�t���̃W�����v��")]
    [SerializeField] float debuffJumpForce = 0;


    //���씽�]
    [Header("���씽�]�f�o�t")]
    public bool reverse;
    int reversDir = 1;

    //���쒴��
    [Header("�p���[�A�b�v�f�o�t")]
    public bool powerUpDebuff;

    [SerializeField, Header("�f�o�t��Ԃ�\������")]
    private DisplayPlayerDebuff displayPlayerDebuff;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        reversDir = 1;
        gameStageManager = Locator<GameStageManager>.GetT();
    }

    // Update is called once per frame
    void Update()
    {
        key = 0;

        //�L�[�̓��͊��m
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;

        // �L�[���͂�������������A�j���[�V�����Ɉړ�����
        if (key != 0f)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }

        //���씽�]�f�o�t
        if (reverse)
        {
            displayPlayerDebuff.ShowMoveReverseUi();
            key *= -1;
        }
        else
        {
            displayPlayerDebuff.HideMoveReverseUi();
        }

        //�p���[�A�b�v�f�o�t
        if (!powerUpDebuff)
        {
            displayPlayerDebuff.HideBuffUi();
            moveForce = normalMoveForce;
            jumpForce = normalJumpForce;
        }
        else
        {
            displayPlayerDebuff.ShowBuffUi();
            moveForce = debuffMoveForce;
            jumpForce = debuffJumpForce;
        }


        MoveControll(key);      //�����̐���
        ScaleControll(key);     //�����̐���


        if (Input.GetKeyDown(KeyCode.UpArrow) && rigid2D.velocity.y == 0)
        {
            this.animator.SetTrigger("JumpTrigger");
            JumpControll(jumpForce);
        }
    }

    void MoveControll(int key)  //���E�ړ�
    {
        dir = Vector3.zero;
        dir = rigid2D.velocity;
        dir.x = key * moveForce;
        rigid2D.velocity = dir;
    }

    void JumpControll(float jumpForce)  //�W�����v
    {
        Vector2 vel = rigid2D.velocity;
        vel.y = 0;
        rigid2D.velocity = vel;

        rigid2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void ScaleControll(int key)  //��������
    {
        if (key != 0)
        {
            Vector3 scl = transform.localScale;

            scl.x = Mathf.Abs(scl.x) * key;
            transform.localScale = scl;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GimmickSeed gimmickSeed = collision.gameObject.GetComponent<GimmickSeed>();
        GimmickKinds gimmickKind = gimmickSeed.GetGimmickKindType();
        gameStageManager.TouchGimmickRight(this, gimmickKind);
    }
}
