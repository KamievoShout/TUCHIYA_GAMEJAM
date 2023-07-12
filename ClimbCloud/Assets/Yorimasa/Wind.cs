using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    private Rigidbody2D plRb;

    // 風関係のタイマー
    private float windCtr=0;
    private float windWait = 60;

    // 風の強さ

    void Start()
    {
        plRb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        windCtr += 1.0f;
        if ( windCtr >= windWait )
        {

            windCtr = 0;
        }
    }
}
