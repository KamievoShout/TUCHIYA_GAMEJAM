using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObj;

    private Camera camera;
    private float cameraSize;

    private const float offset = 4.5f;

    private void Awake()
    {
        camera = GetComponent<Camera>();
        cameraSize = camera.orthographicSize;
    }

    void Start()
    {

    }

    void Update()
    {
        Vector3 playerPos = playerObj.transform.position;
        transform.position = new Vector3(transform.position.x, playerPos.y + cameraSize - offset, transform.position.z);
    }
}
