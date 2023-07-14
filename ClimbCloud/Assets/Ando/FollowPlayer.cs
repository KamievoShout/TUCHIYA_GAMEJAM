using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform playerTransform;

    private void LateUpdate()
    {
        if (playerTransform != null)
        {
            Vector3 newPosition = transform.position;
            newPosition.y = playerTransform.position.y;
            transform.position = newPosition;
        }
    }
}
