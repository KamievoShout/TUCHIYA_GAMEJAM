using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using Utility;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    float moveSpeed;             // �ړ����x

    [Header("�W�����v")]
    [SerializeField]
    float jumpPower = 300;       // �W�����v��

    [SerializeField]
    float chargeSpeed;           // ���߂̑���

    [SerializeField] 
    float AccumulateLimit;       // �W�����v�̗��߂̏��

    [SerializeField]
    AnimationCurve animCurve;    // �W�����v�̋O��

    [SerializeReference]
    GameObject spriteObj;

    [SerializeField]
    ParticleSystem dethEffect;

    [SerializeField]
    ParticleSystem stunEffect;

    [SerializeField]
    Slider jumpPowerSlider;

    [SerializeField]
    Slider stunTimeSlider;

    [SerializeField]
    Animator animator;

    [SerializeField]
    float stanTime;

    Rigidbody2D rb;
    float inputX;
    float jumpAccumulat;
    bool isGround;
    bool isControl;

    bool flg;
    Tween tween;


    public event Action OnDead;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGround = true;
        isControl = true;

        flg = false;

        Locator<PlayerController>.Register(this);
    }

    // Update is called once per frame
    void Update()
    {

        if (!isControl) return;

        // �ړ�
        inputX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(inputX * moveSpeed, rb.velocity.y);


        // �W�����v
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jumpAccumulat = 0.0f;        // �W�����v�̗��߂�������
            jumpPowerSlider.gameObject.SetActive(true);
        }


        if (isGround)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Jump();
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                if (AccumulateLimit >= jumpAccumulat)
                {
                    jumpAccumulat += Time.deltaTime * chargeSpeed;
                    jumpPowerSlider.value = jumpAccumulat / AccumulateLimit;
                }
            }
        }
        else if(rb.velocity.y < 0f)
        {
            tween?.Kill();
            tween = spriteObj.transform.DOScale(new Vector3(1.25f, 0.75f, 0.0f), 0.25f);
        }
    }

    void Jump()
    {
        float force = jumpPower * animCurve.Evaluate(jumpAccumulat);
        tween?.Kill();
        tween = spriteObj.transform.DOScale(new Vector3(0.5f, 1.5f), 0.25f);

        isGround = false;

        rb.AddForce(Vector2.up * force, ForceMode2D.Force);

        jumpPowerSlider.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if(!isGround)
            {
                isGround = true;

                tween?.Kill();
                tween = spriteObj.transform.DOScale(new Vector3(1.0f, 1.0f, 0.0f), 0.2f);
            }
        }
    }

    public void Death()
    {
        isControl = false;
        spriteObj.SetActive(false);
        dethEffect.Play();
        OnDead?.Invoke();
    }

    public void Stan()
    {
        if (!flg)
        {
            stunEffect.Play();
            flg = true;
            isControl = false;
            animator.Play("PL_stanAnimation");
            stunTimeSlider.gameObject.SetActive(true);
            DOVirtual.Float(0, 1, stanTime, x => 
            {
                stunTimeSlider.value = x;
            }).
            onComplete += () =>
            {
                stunTimeSlider.gameObject.SetActive(false);
                isControl = true;
                animator.Play("PL_defaultAnimation");
                flg = false;
            };
        }
    }
}