using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private Image backgroundImage;

    private float dayLength = 10f;
    private float timer = 0.5f;
    private bool isDay = true;

    private Material backgroundMaterial;
    

    void Start()
    {
        backgroundMaterial = backgroundImage.material;
    }

    void Update()
    {
        Rot(moonObj,moonRotSpeed, false);
        Rot(sunObj,sunRotSpeed, false);

        //timer -= 1f / dayLength * Time.deltaTime;
        //timer = Mathf.Sin(timer);

        //float day = timer / dayLength;
        //day = Mathf.Abs(1 - day);
        //backgroundMaterial.SetFloat("_Day", Mathf.Abs(Mathf.Sin(timer/2f)));

        //if (timer >= dayLength)
        //{
        //    timer = 0f;
        //    isDay = !isDay;
            
        //    Debug.Log("�����o��" + isDay);
        //}
    }

    /// <summary>
    /// ���̃I�u�W�F�N�g�𒆐S�Ƃ��đ��̃I�u�W�F�N�g����]������
    /// </summary>
    /// <param name="obj">��]���������I�u�W�F�N�g</param>
    /// <param name="rotSpeed">��]���x</param>
    /// <param name="isLocalRot">��]���������I�u�W�F�N�g���̂���]���邩�H</param>
    private void Rot(GameObject obj, float rotSpeed, bool isLocalRot = true)
    {
        float angle = (180f / dayLength) * Time.deltaTime;
        obj.transform.RotateAround(this.transform.position, Vector3.back, angle);

        if(!isLocalRot)
        {
            obj.transform.localRotation = Quaternion.identity;
        }
    }
}
