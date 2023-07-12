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
   public float jumpForce = 0f;
   public float walkForce = 0f;
    public float maxWalkSpeed = 0f;

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

        if(Input.GetKeyDown(KeyCode.R) || transform.position.y < -10)
        {
            transform.position = new Vector3(0, 0, 0);
            this.rigid2D.AddForce(-transform.up * this.jumpForce);
        }




        if(Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity .y == 0)
        {
            this.animator.SetTrigger("JumpTrigger");
            //AddForce:Rigidbodyのメンバ変数の一つで、「オブジェクトに力を加えることができる」メソッド。
            //今回は「transform.up * jumpForce」としているので、上方向にjumpForce分の力が加わる。upは上方向、つまりYと同義で*(0,jumpForce,0)と同じことをしている。
            this.rigid2D.AddForce(transform.up * this.jumpForce);
            
        }


        int key  = 0;
        if(Input.GetKey(KeyCode.RightArrow)) key = 1;
        if(Input.GetKey(KeyCode.LeftArrow)) key = -1;

        float speedx = Mathf.Abs(this.rigid2D.velocity.x);


        if(speedx < this.maxWalkSpeed)//AddForceは力をかけ続けるメソッド。続けているとどんどん力が加算されてめちゃくちゃ早くなる。なので、最大速度を変数で設定し、動きが早くなりすぎるのを防いでいる
        {
            this.rigid2D.AddForce(transform.right * key * walkForce);
        }

        if(key != 0)　//keyが0じゃない＝押されているとき
        {
            transform.localScale = new Vector3(key,1,1);//このオブジェクトのスケールを変更している。keyは右が押されたときは１,左は-1なので、左を押したときに反転することがわかる
        }

        this.animator.speed = speedx /  2.0f;

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


     void OnTriggerEnter2D(Collider2D other)
    {
        Initiate.Fade("ClearScene", fadeColor, fadeSpeedMultiplier);
        Debug.Log("Goal");
    }
}

