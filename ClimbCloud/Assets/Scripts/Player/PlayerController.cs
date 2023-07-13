using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

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

        // �ړ�
        inputX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(inputX * moveSpeed, rb.velocity.y);


        // �W�����v
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jumpAccumulat = 0.0f;        // �W�����v�̗��߂�������
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
