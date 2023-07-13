using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloud : MonoBehaviour
{
    // Rigidbody2D rb2D;

    public bool axisX = true;
    public bool axisY = false;

    public int moveDir = 1;

    public float moveSpd = 0.1f;
    public float moveAmount = 3;

    float nowMoveAmount = 0;

    void Start()
    {
        // rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 pos = this.transform.position;
        if (axisX)
        {
            pos.x += moveSpd * moveDir;
        }
        if (axisY)
        {
            pos.y += moveSpd * moveDir;
        }
        this.transform.position = pos;

        nowMoveAmount += moveSpd;
        if (nowMoveAmount >= moveAmount)
        {
            nowMoveAmount = 0;
            moveDir *= -1;
        }
    }
}
