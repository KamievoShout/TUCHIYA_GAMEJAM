using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Color fadeColor = Color.black;
    [SerializeField] private float fadeSpeedMultiplier = 1.0f;

    Rigidbody2D rigid2D;
    Animator animator;

    [SerializeField] float jumpForce = 0f;      //�W�����v��
    [SerializeField] float moveForce = 0f;      //���s���x
    [SerializeField] float maxWalkSpeed = 0f;

    Vector3 dir = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < -10)
        {
            transform.position = new Vector3(0, 0, 0);
            this.rigid2D.AddForce(-transform.up * this.jumpForce);
        }




        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
        {
            this.animator.SetTrigger("JumpTrigger");
            //AddForce:Rigidbody�̃����o�ϐ��̈�ŁA�u�I�u�W�F�N�g�ɗ͂������邱�Ƃ��ł���v���\�b�h�B
            //����́utransform.up * jumpForce�v�Ƃ��Ă���̂ŁA�������jumpForce���̗͂������Bup�͏�����A�܂�Y�Ɠ��`��*(0,jumpForce,0)�Ɠ������Ƃ����Ă���B
            this.rigid2D.AddForce(transform.up * this.jumpForce);

        }


        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        float speedx = Mathf.Abs(this.rigid2D.velocity.x);


        if (speedx < this.maxWalkSpeed)//AddForce�͗͂����������郁�\�b�h�B�����Ă���Ƃǂ�ǂ�͂����Z����Ă߂��Ⴍ���ᑁ���Ȃ�B�Ȃ̂ŁA�ő呬�x��ϐ��Őݒ肵�A�����������Ȃ肷����̂�h���ł���
        {
            this.rigid2D.AddForce(transform.right * key * moveForce);
        }

        if (key != 0) //key��0����Ȃ���������Ă���Ƃ�
        {
            transform.localScale = new Vector3(key, 1, 1);//���̃I�u�W�F�N�g�̃X�P�[����ύX���Ă���Bkey�͉E�������ꂽ�Ƃ��͂P,����-1�Ȃ̂ŁA�����������Ƃ��ɔ��]���邱�Ƃ��킩��
        }

        this.animator.speed = speedx / 2.0f;

        if (this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = speedx / 2.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }

        //if(transform.position.y < 10)
        //{
        //    SceneManager.LoadScene("Main");
        //}

    }

    void LeftPlayerController()
    {
        int key = 0;
        if (Input.GetKey(KeyCode.A)) key = 1;
        if (Input.GetKey(KeyCode.D)) key = -1;

        dir = Vector3.zero;
        dir = rigid2D.velocity;
        dir.x = key * moveForce;
        rigid2D.velocity = dir;


        if (Input.GetKeyDown(KeyCode.W))    //�W�����v
        {
            JumpControll();
        }

        ScaleControll(key);

    }

    void RightPlayerController()
    {
        int key = 0;
        if (Input.GetKey(KeyCode.LeftArrow)) key = 1;
        if (Input.GetKey(KeyCode.RightArrow)) key = -1;

        MoveControll(key);

        ScaleControll(key);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            JumpControll();
        }
    }

    void MoveControll(int key)
    {
        dir = Vector3.zero;
        dir = rigid2D.velocity;
        dir.x = key * moveForce;
        rigid2D.velocity = dir;
    }

    void JumpControll()
    {
        Vector2 vel = rigid2D.velocity;
        vel.y = 0;              //Y�̑��x��������
        rigid2D.velocity = vel;    //��̏������𔽉f

        //�W�����v�͂�������
        rigid2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void ScaleControll(int key)
    {
        if (key != 0)
        {
            Vector3 scl = transform.localScale;

            //Mathf.Abs:��Βl�̂���
            scl.x = Mathf.Abs(scl.x) * key;       //�����ݒ�
            transform.localScale = scl;               //�g�k�ݒ�
        }
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        Initiate.Fade("ClearScene", fadeColor, fadeSpeedMultiplier);
        Debug.Log("Goal");
    }
}
