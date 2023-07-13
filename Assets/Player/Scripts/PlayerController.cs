using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Collider2D circleCollider2d;
    [SerializeField] float jumpForce = 680.0f;
    [SerializeField] float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;
    float inputDirKey;                  // �����L�[���͂̌���
    bool inputJumpKey;                  // �W�����v�L�[����
    [SerializeField] LayerMask lMask;   // ���C���[�}�X�N
    AnimationController animScript;     // �A�j���[�V�����Ǘ��X�N���v�g

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


#if false
        // �W�����v����
        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
        {
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        // ���E�ړ�
        float key = 0;
        key = Input.GetAxisRaw("Horizontal");

        // �v���C���[�̑��x
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        // �X�s�[�h����
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        // ���������ɉ����Ĕ��]
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        // �v���C���[�̑��x�ɉ����ăA�j���[�V�������x��ς���
        if (this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = speedx / 2.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }

        // ��ʊO�ɏo���ꍇ�͍ŏ�����
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }
#endif
    }

    private void FixedUpdate()
    {
        if (CheckCloud())
        {
            // �n�ʂɂ���Ƃ��̏���
            // �W�����v�L�[��������Ă��邩
            if (inputJumpKey)
            {
                // ���x������
                Vector2 vel = rigid2D.velocity;
                vel.y = 0;
                rigid2D.velocity = vel;

                // �W�����v����
                rigid2D.AddForce(transform.up * this.jumpForce);

                // Jump�A�j���[�V�����Đ�
                animScript.AnimPlay(AnimationController.animationParameter.Jump);
                // �T�E���h�Đ�

            }
        }

        // ���E�L�[��������Ă��邩
        if (inputDirKey != 0)
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

            // Walk�A�j���[�V�����Đ�
            animScript.AnimPlay(AnimationController.animationParameter.Walk);
        }
        else
        {
            // ������Ă��Ȃ��Ƃ�
            // Stay�A�j���[�V����
            animScript.AnimPlay(AnimationController.animationParameter.Stay);

        }
    }

    // �S�[���ɓ��B
    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("ClearScene");
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
        Vector3 rayStart = GetFootPos() * 1.1f;     // ���C�̃X�^�[�g
        rayStart.x -= colRadiusX;
        Vector3 rayEnd = GetFootPos() * 1.1f;     // ���C�̏I���
        rayEnd.x += colRadiusX;

        // ���C�ˏo
        RaycastHit2D rayResult;
        rayResult = Physics2D.Linecast(rayStart, rayEnd, lMask);
        Debug.DrawLine(rayStart, rayEnd);
        if (rayResult.collider != null)
        {
            // ���C���_�Ƀq�b�g�����Ƃ�
            isGround = true;
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
}
