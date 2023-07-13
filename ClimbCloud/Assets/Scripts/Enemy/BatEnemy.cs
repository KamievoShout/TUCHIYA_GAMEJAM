using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatEnemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float moveRangeMin = -128;
    [SerializeField] private float moveRangeMax = 128;
    [SerializeField] private int firstMoveDir = 1;

    private int moveDir;

    private void Start()
    {
        moveDir = firstMoveDir;
    }

    private void Update()
    {
        transform.position += new Vector3(moveSpeed * Time.deltaTime * moveDir, 0, 0);

        if (transform.position.x >= moveRangeMax)
        {
            moveDir = -1;
            transform.localScale = new Vector3(moveDir, 1, 1);
        }
        else
        if(transform.position.x <= moveRangeMin)
        {
            moveDir = 1;
            transform.localScale = new Vector3(moveDir, 1, 1);
        }
    }
}
