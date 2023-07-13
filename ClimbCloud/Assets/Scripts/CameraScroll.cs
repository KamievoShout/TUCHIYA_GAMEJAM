using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    [Tooltip("カメラの移動速度です")]
    [SerializeField] private float scrollspeed;
    void Start()
    {
    }

    void Update()
    {
        gameObject.transform.position += new Vector3(0, scrollspeed, 0) ;
    }

    //クリア時にカメラのポジションを初期値に戻す
    public void CameraposReset()
    {
        gameObject.transform.position = Vector3.zero;
    }
}
