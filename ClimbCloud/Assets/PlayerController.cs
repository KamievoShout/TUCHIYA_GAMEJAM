using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;      //LoadScene���g�����߂ɕK�v�I�I

public class PlayerController : MonoBehaviour
{
    Vector3 movePos = Vector3.zero;

    Rigidbody2D rigid2D;
    Animator animator;
    
    // �Q�[���V�[����
    [SerializeField] private string GameSceneName = "GameScene";
    // �����̓����蔻��␳
    [SerializeField] private float UnderRayAsist = 0.35f;
    // �������ɉ������
    [SerializeField] private float WalkForce = 0.15f;
    // ��ԂƂ��ɉ������
    [SerializeField] private float JumpForce = 0.15f;
    // ��ԃX�s�[�h
    [SerializeField] private float JumpSpeed = 1;
    // �d��
    [SerializeField] private float GravityScale = 0.15f;
    // �ǂɐG��Ă���Ƃ��ɂ�����ǂƂ̖��C�����������d��(�Ƃ�������)
    [SerializeField] private float isWallGravityScale = 0.15f;
    // �n�ʂ̃��C���[�}�X�N
    [SerializeField] private LayerMask GroundLayerMask;
    // �ǂ̃��C���[�}�X�N
    [SerializeField] private LayerMask WallLayerMask;

    // ���g�̓����蔻��T�C�Y
    private Vector2 myColliderSize;

    // �ȉ�true����
    // �n�ʂɐݒu���Ă���
    private bool isGround = true;
    // �ǂɐG��Ă���
    private bool isWall = false;
    // �W�����v���Ă���
    private bool jump = false;
    // �ǂ������Ă���
    private bool WallKick = false;
    // �E�̕ǂɐG��Ă���
    private bool isRightWall = true;

    int i = 0;
    int j = 0;

    private float[,] jumpvec = { { 1, 0.9f, 0.8f, 0.7f, 0.6f, 0.5f,  0.4f,  0.3f,  0.2f,  0.1f,  0 },       // x�ψ�
                                 { 1, 0.8f, 0.4f, 0.2f, 0.1f,    0, -0.1f, -0.2f, -0.3f, -0.6f, -1 } };     // y�ψ�
    private int[] jumptime =     { 10,  10,    5,    2,    1,   20,    12,     8,     4,     4, -1 };       //���ꂼ�ꉽ�t���[���͂������邩

    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();

        // ���g�̃X�P�[�����������������蔻��̑傫�����擾
        myColliderSize = this.GetComponent<BoxCollider2D>().bounds.size;
    }

    void Update()
    {
        PlayerMove();
    }

    //�S�[���ɓ���
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Goal")
        {
            Debug.Log("�S�[��");
            SceneManager.LoadScene("ClearScene");
        }
    }

    // Player�̈ړ����s��
    private void PlayerMove()
    {
        movePos = this.transform.position;

        //���E�ړ�
        float key = 0;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) key = -1;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGround)       // �ʏ�W�����v
            {
                jump = true;
                this.animator.SetTrigger("JumpTrigger");
            }
            else if (isWall)    // �ǃL�b�N
            {
                jump = true;
                WallKick = true;
                this.animator.SetTrigger("JumpTrigger");
            }
        }

        if (jump)
        {
            // y�̕ψʂ�������
            movePos.y += jumpvec[1, i] * JumpForce * JumpSpeed * Time.deltaTime;

            // �ǃL�b�N�����Ă���Ƃ���x�̕ψʂ�������
            if (WallKick)
            {
                key /= 1.2f;
                if (isRightWall)
                {
                    key += -jumpvec[0, i] * 1.5f;
                }
                else
                {
                    key += jumpvec[0, i] * 1.5f;
                }
            }

            if (j < jumptime[i] / JumpSpeed)
            {
                ++j;
            }
            else if (jumptime[i] == -1)         // �W�����v�I��
            {
                WallKick = false;
                JumpFinish();
            }
            else
            {
                j = 0;
                ++i;
            }
        }
        else if (isWall)
        {
            movePos.y -= isWallGravityScale * Time.deltaTime;
        }
        else
        {
            // �d��
            movePos.y -= GravityScale * Time.deltaTime;
        }

        // x�̍ŏI�I�ȕψʂ�������
        movePos.x += key * WalkForce * Time.deltaTime;

        //���������ɉ����Ĕ��]
        if (key != 0)
        {
            if (key > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        // ���g�̃|�W�V����
        Vector2 myPos = this.transform.position;



        isWall = false;

        // �E�̕ǔ���
        RaycastHit2D hit = Physics2D.Raycast(myPos, Vector3.right, 100, WallLayerMask);

        if (hit.collider && movePos.x + myColliderSize.x / 2 > hit.transform.position.x - hit.collider.bounds.size.x / 2)
        {
            movePos.x = hit.transform.position.x - hit.collider.bounds.size.x / 2 - myColliderSize.x / 2;
            isWall = true;
            isRightWall = true;
            JumpFinish();
        }

        // ���̕ǔ���
        hit = Physics2D.Raycast(myPos, Vector3.left, 100, WallLayerMask);

        if (hit.collider && movePos.x - myColliderSize.x / 2 < hit.transform.position.x + hit.collider.bounds.size.x / 2)
        {
            movePos.x = hit.transform.position.x + hit.collider.bounds.size.x / 2 + myColliderSize.x / 2;
            isWall = true;
            isRightWall = false;
            JumpFinish();
        }

        // ���C�̔����n�_�𑫌��ɕύX����B
        myPos.y -= myColliderSize.y / 2 + UnderRayAsist;

        hit = Physics2D.Raycast(myPos, Vector3.down, 100, GroundLayerMask);

        if (hit.collider && movePos.y < hit.transform.position.y + myColliderSize.y / 2 + hit.collider.bounds.size.y / 2)
        {
            isGround = true;
            movePos.y = hit.transform.position.y + myColliderSize.y / 2 + hit.collider.bounds.size.y / 2;
            JumpFinish();
        }
        else
        {
            // ��
            isGround = false;
        }

        // �ړ�
        this.transform.position = movePos;

        //��ʊO�ɏo���ꍇ�͍ŏ�����
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene(GameSceneName);
        }
    }

    private void JumpFinish()
    {
        jump = false;
        WallKick = false;
        i = 0; j = 0;
        Debug.Log("�S�[��");
        //SceneManager.LoadScene("ClearScene");
    }
}