using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundObjRotObjRot : MonoBehaviour
{
    [SerializeField]
    private float moonRotSpeed = 1f;

    [SerializeField]
    private GameObject moonObj;

    [SerializeField]
    private float sunRotSpeed = 1f;

    [SerializeField]
    private GameObject sunObj;

    [SerializeField]
    private float airplaneRotSpeed = 1f;

    [SerializeField]
    private GameObject airplaneObj;


    void Start()
    {
        
    }

    void Update()
    {
        Rot(moonObj,-moonRotSpeed, false);
        Rot(sunObj,-sunRotSpeed, false);
        Rot(airplaneObj,-airplaneRotSpeed, false);

    }

    /// <summary>
    /// このオブジェクトを中心として他のオブジェクトを回転させる
    /// </summary>
    /// <param name="obj">回転させたいオブジェクト</param>
    /// <param name="rotSpeed">回転速度</param>
    /// <param name="isLocalRot">回転させたいオブジェクト自体も回転するか？</param>
    private void Rot(GameObject obj, float rotSpeed, bool isLocalRot = true)
    {
        float angle = 360f / (1f / rotSpeed) * Time.deltaTime;
        obj.transform.RotateAround(this.transform.position, Vector3.forward, angle);
        obj.transform.localRotation = Quaternion.identity;
    }
}
