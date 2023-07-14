using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using Utility;
using UnityEngine.UI;
using Utility.Audio;
using StageObject;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    float moveSpeed;             // 移動速度

    [Header("ジャンプ")]
    [SerializeField]
    float jumpPower = 300;       // ジャンプ力

    [SerializeField]
    float chargeSpeed;           // 溜めの速さ

    [SerializeField] 
    float AccumulateLimit;       // ジャンプの溜めの上限

    [SerializeField]
    AnimationCurve animCurve;    // ジャンプの軌道

    [SerializeReference]
    GameObject spriteObj;

    [SerializeField]
    ParticleSystem dethEffect;

    [SerializeField]
    ParticleSystem stunEffect;

    [SerializeField]
    ParticleSystem chargeEffect;

    [SerializeField]
    ParticleSystem jumpEffect;

    [SerializeField]
    Slider jumpPowerSlider;

    [SerializeField]
    Slider stunTimeSlider;

    [SerializeField]
    Animator animator;

    [SerializeField]
    float stanTime;

    [SerializeField] 
    private AfterImage aft;

    Rigidbody2D rb;
    float inputX;
    float jumpAccumulat;
    bool isGround;
    bool isControl;

    bool isStun;
    Tween tween;


    public event Action OnDead;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGround = true;
        isControl = true;

        isStun = false;

        Locator<PlayerController>.Register(this);
    }

    // Update is called once per frame
    void Update()
    {

        if (!isControl) return;

        // 移動
        inputX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(inputX * moveSpeed, rb.velocity.y);


        // ジャンプ
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jumpAccumulat = 0.0f;        // ジャンプの溜めを初期化
            jumpPowerSlider.gameObject.SetActive(true);
            chargeEffect.Play();
        }


        if (isGround && !isStun)
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
            tween = spriteObj.transform.DOScale(new Vector3(1.25f, 0.75f, 0.0f), 0.25f).SetLink(gameObject);
        }
    }

    void Jump()
    {
        float force = jumpPower * animCurve.Evaluate(jumpAccumulat);
        tween?.Kill();
        tween = spriteObj.transform.DOScale(new Vector3(0.5f, 1.5f), 0.25f).SetLink(gameObject);
        chargeEffect.Stop();
            jumpEffect.Play();

        isGround = false;

        rb.AddForce(Vector2.up * force, ForceMode2D.Force);

        jumpPowerSlider.gameObject.SetActive(false);
        Locator<IPlayAudio>.Resolve().PlaySE("PlayerJump");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if(!isGround)
            {
                isGround = true;

                tween?.Kill();
                tween = spriteObj.transform.DOScale(new Vector3(1.0f, 1.0f, 0.0f), 0.2f).SetLink(gameObject);
            }
        }
    }

    public void Death()
    {
        isControl = false;
        spriteObj.SetActive(false);
        dethEffect.Play();
        OnDead?.Invoke();
        Locator<IPlayAudio>.Resolve().PlaySE("PlayerDead");
    }

    public void Stan()
    {
        if (!isStun)
        {
            Locator<IPlayAudio>.Resolve().PlaySE("PlayerStun");
            stunEffect.Play();
            isStun = true;
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
                isStun = false;
            };
        }
    }
}
