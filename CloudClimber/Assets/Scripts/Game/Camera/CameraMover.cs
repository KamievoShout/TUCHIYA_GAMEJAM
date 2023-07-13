using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UniRx;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public GameObject playerObj;
    public float lerpSpeed = 0.1f;

    private FloorArea currentArea = null;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        MessageBroker.Default.Receive<FloorArea>()
            .Subscribe(area => currentArea = area)
            .AddTo(this);
    }

    public void SetArea(FloorArea area)
    {
        currentArea = area;
    }

    private void LateUpdate()
    {
        if (currentArea == null) return;
        if (playerObj == null) return;

        Vector2 cameraSize = new Vector2(mainCamera.orthographicSize * 2, mainCamera.orthographicSize * 2);

        Vector2 moveRange = (currentArea.Size - cameraSize) * 0.5f;
        moveRange.x = Mathf.Max(0.0f, moveRange.x);
        moveRange.y = Mathf.Max(0.0f, moveRange.y);

        Vector2 min = (Vector2)currentArea.transform.position - moveRange;
        Vector2 max = (Vector2)currentArea.transform.position + moveRange;

        Vector3 position = playerObj.transform.position;
        position.x = Mathf.Clamp(position.x, min.x, max.x);
        position.y = Mathf.Clamp(position.y, min.y, max.y);

        position.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, position, lerpSpeed);
    }
}
