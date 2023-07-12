using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleDirector : MonoBehaviour
{
    [SerializeField] private string loadScene;
    [SerializeField] private Color fadeColor = Color.black;
    [SerializeField] private float fadeSpeedMultiplier = 1.0f;

    public float jumpForce = 0f;
    Rigidbody2D rigid2D;
    Animator animator;
    GameObject cat;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60; ;
        this.animator = GetComponent<Animator>();
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.speed =  2.0f;

        if(Input.GetMouseButton(0))
        {
            Initiate.Fade(loadScene, fadeColor, fadeSpeedMultiplier);
            //transform.position = new Vector3(0, jumpForce, 0 * Time.deltaTime);
            //this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

    }
}
