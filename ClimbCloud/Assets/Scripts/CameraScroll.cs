using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    [Tooltip("�J�����̈ړ����x�ł�")]
    [SerializeField] private float scrollspeed;
    void Start()
    {
    }

    void Update()
    {
        gameObject.transform.position += new Vector3(0, scrollspeed, 0) ;
    }

    //�N���A���ɃJ�����̃|�W�V�����������l�ɖ߂�
    public void CameraposReset()
    {
        gameObject.transform.position = Vector3.zero;
    }
}
