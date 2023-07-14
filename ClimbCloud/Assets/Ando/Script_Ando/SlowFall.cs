using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowFall : MonoBehaviour
{
    public float fallSpeed = 2f; // 落下速度
    public float fallDuration = 3f; // 落下時間

    private float elapsedTime = 0f; // 経過時間
    private bool isFalling = false; // 落下中かどうかのフラグ
    private Vector3 initialPosition; // 初期位置

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !isFalling)
        {
            StartFalling();
        }

        if (isFalling)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= fallDuration)
            {
                StopFalling();
            }
            else
            {
                float t = elapsedTime / fallDuration;
                transform.position = Vector3.Lerp(initialPosition, initialPosition + Vector3.down, t);
            }
        }
    }

    private void StartFalling()
    {
        isFalling = true;
        elapsedTime = 0f;
    }

    private void StopFalling()
    {
        isFalling = false;
        transform.position = initialPosition;
        elapsedTime = 0f;
    }
}
