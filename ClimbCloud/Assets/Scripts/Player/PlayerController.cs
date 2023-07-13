using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

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

    Rigidbody2D rb;
    float inputX;
    float jumpAccumulat;
    bool isGround;
    public bool isControl;

    Tween tween;


    public event Action OnDaed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGround = true;
        isControl = true;
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
                    jumpAccumulat += Time.deltaTime * chargeSpeed;
                Debug.Log(jumpAccumulat);
            }
        }
        else if(rb.velocity.y<=0.1f)
        {
            tween?.Kill();
            tween = spriteObj.transform.DOScale(new Vector3(1.0f, 1.0f, 0.0f), 0.2f);
        }
    }

    void Jump()
    {
        float force = jumpPower * animCurve.Evaluate(jumpAccumulat);

        spriteObj.transform.DOScale(new Vector3(0.5f, 1.5f), 0.25f);

        isGround = false;

        rb.AddForce(Vector2.up * force, ForceMode2D.Force);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if(!isGround)
            {
                isGround = true;
                spriteObj.transform.DOScale(new Vector3(1.5f, 0.5f), 0.15f).onComplete += () =>
                {
                    //spriteObj.transform.DOScale(new Vector3(1f, 1f), 0.3f);
                };
                spriteObj.transform.DOLocalMoveY(-2f, 0.15f).onComplete += () =>
                {
                    spriteObj.transform.DOLocalMoveY(0f, 0.3f);               
                };
            }
        }


    }

    public void Death()
    {
        spriteObj.SetActive(false);
        dethEffect.Play();
        OnDaed?.Invoke();
    }
}
