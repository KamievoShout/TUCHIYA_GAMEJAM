using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

enum jumpState
{
    notJumping,
    singleJump,
    doubleJump,
    falling
}

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Collider2D circleCollider2d;
    [SerializeField] float jumpForce = 680.0f;
    [SerializeField] float walkForce = 30.0f;
    float inputDirKey;                  // �����L�[���͂̌���
    bool inputJumpKey;                  // �W�����v�L�[����
    [SerializeField] LayerMask lMask;   // ���C���[�}�X�N
    AnimationController animScript;     // �A�j���[�V�����Ǘ��X�N���v�g
    Vector3 jumpedPos;                  // �W�����v�����ʒu
    jumpState nowJumpState;             // �_�u���W�����v���\��
    [SerializeField]
    Vector2 doubleJumpForce =           // �_�u���W�����v�̗�
        new Vector2(10f, 4f);
    public bool isGoal = false;         // �S�[��������
    bool isPlaySE;                      // �_��SE���Đ��ł��邩

    void Start()
    {
        Application.targetFrameRate = 30;
        circleCollider2d = GetComponent<Collider2D>();
        this.rigid2D = GetComponent<Rigidbody2D>();
        animScript = GetComponent<AnimationController>();

        animScript.AnimInit();
    }

    void Update()
    {
        // �����L�[�̓��͎擾
        inputDirKey = 0;
        inputDirKey = Input.GetAxisRaw("Horizontal");

        // �W�����v�L�[�̓��͎擾
        inputJumpKey = Input.GetButtonDown("Jump");

    }

    private void FixedUpdate()
    {
        // 2�i�W�����v��L����
        if (CheckCloud()) nowJumpState = jumpState.notJumping;
        else isPlaySE = true;

        if (inputJumpKey && nowJumpState != jumpState.falling)
        {
            // ���x������
            Vector2 vel = rigid2D.velocity;
            vel.y = 0;
            rigid2D.velocity = vel;

            // �T�E���h�Đ�
            //SeManager.Instance.Play("Jump");

            // �n�ʂɂ���Ƃ��̏���
            // �W�����v�L�[��������Ă��邩
            if (CheckCloud())
            {
                // �W�����v����
                rigid2D.AddForce(transform.up * this.jumpForce);
                nowJumpState = jumpState.singleJump;
                // Jump�A�j���[�V�����Đ�
                animScript.AnimPlay(AnimationController.animationParameter.Jump);

                // �W�����v�����ʒu�擾
                jumpedPos = transform.position;

                inputJumpKey = false;
            }
            else if (nowJumpState != jumpState.doubleJump)
            {
                // �����Ă�������փ_�u���W�����v
                doubleJumpForce.x = Mathf.Abs(doubleJumpForce.x) * transform.localScale.x;

                rigid2D.AddForce(doubleJumpForce);
                nowJumpState = jumpState.doubleJump;

                // DoubleJump�A�j���[�V�����Đ�
                animScript.AnimPlay(AnimationController.animationParameter.DoubleJump);

                inputJumpKey = false;
            }
        }

        // �_�u���W�����v�������ʒu���Ƃ񂾏ꏊ��艺�̎�
        if(nowJumpState == jumpState.doubleJump && transform.position.y < jumpedPos.y)
        {
            nowJumpState = jumpState.falling;
            // Jump�A�j���[�V�����Đ�
            animScript.AnimPlay(AnimationController.animationParameter.Jump);
        }

        // ���E�L�[��������Ă��邩 ���_�u���W�����v�����Ă��Ȃ�
        if (inputDirKey != 0 && nowJumpState != jumpState.doubleJump)
        {
            // ���͕����ֈړ�������
            Vector2 position = rigid2D.velocity;
            position.x = walkForce * inputDirKey;
            rigid2D.velocity = position;

            // �i�s����������
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x);       // ������
            scale.x *= inputDirKey;
            transform.localScale = scale;
            if (CheckCloud())
            {
                // Walk�A�j���[�V�����Đ�
                animScript.AnimPlay(AnimationController.animationParameter.Walk);
            }
        }
        else if (CheckCloud())
        {
            // ������Ă��Ȃ��Ƃ�
            // Stay�A�j���[�V����
            animScript.AnimPlay(AnimationController.animationParameter.Stay);
        }
    }

    // �S�[���ɓ��B
    void OnTriggerEnter2D(Collider2D other)
    {
        isGoal = true;
        SceneManager.LoadScene("ClearScene");
        SeManager.Instance.Play("Goal");
    }

    /// <summary>
    /// �_�ɓ���������
    /// </summary>
    /// <returns>[bool] �_�̏�ɂ��邩</returns>
    bool CheckCloud()
    {
        // �ڒn���胊�Z�b�g
        bool isGround = false;
        float colRadiusX = circleCollider2d.bounds.extents.x;

        // ���C�̒����w��
        Vector3 rayStart = GetFootPos();     // ���C�̃X�^�[�g
        rayStart.x -= colRadiusX;
        rayStart.y -= 0.05f;
        Vector3 rayEnd = GetFootPos();     // ���C�̏I���
        rayEnd.x += colRadiusX;
        rayEnd.y -= 0.05f;

        // ���C�ˏo
        RaycastHit2D rayResult;
        rayResult = Physics2D.Linecast(rayStart, rayEnd, lMask);
        Debug.DrawLine(rayStart, rayEnd);
        if (rayResult.collider != null)
        {
            // ���C���_�Ƀq�b�g�����Ƃ�
            isGround = true;
            if(isPlaySE) CloudSE(rayResult.collider.tag);
        }

        return isGround;
    }

    /// <summary>
    /// �����̍��W���擾
    /// </summary>
    /// <returns>[Vector3] �����̍��W</returns>
    Vector3 GetFootPos()
    {
        // cycle�R���C�_�[�̈�ԉ��̍��W���v�Z�Ŏ擾
        Vector3 footPos = circleCollider2d.bounds.center;
        float colRadiusY = circleCollider2d.bounds.extents.y;
        footPos.y -= colRadiusY;

        return footPos;
    }

    // �_SE
    void CloudSE(string tag)
    {
        // ���˂�_
        if(tag == "Bounce")
        {
            //SeManager.Instance.Play("BounceCloud");
        }

        // ����_
        if(tag == "Slip")
        {
            //SeManager.Instance.Play("SlipCloud");
        }

        isPlaySE = false;
    }

    // ��ʊO�ɏo�����ɔ��Α���
    private void OnBecameInvisible()
    {
        Vector3 pos = transform.position;
        pos.x *= -1;
        transform.position = pos;
    }
}
