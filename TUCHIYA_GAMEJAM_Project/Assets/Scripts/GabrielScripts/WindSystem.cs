using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditorInternal.ReorderableList;

public class WindSystem : MonoBehaviour
{
    [SerializeField, Header("���̗^����́iaddforce�j")]
    private float winFor = 10;
    [SerializeField, Header("���̈ړ����x(vector)")]
    private float winSpeed = 5;
    [SerializeField, Header("���̈ړ��͈͂P�C�Q(�K���Q��傫������)")]
    private float winRan1 = -1;
    [SerializeField]
    private float winRan2 = 5;
    [SerializeField, Header("�c�ړ���true ���ȂȂ߈ړ��͎������Ă��Ȃ��ł�")]
    private bool ver = false;
    [SerializeField, Header("����ʍs�ɂ������Ȃ�true")]
    private bool roop = false;
    [SerializeField, Header("���������P��-�P"), Range(-1, 1)]
    private int key = 1;

    private Vector2 thePos;
    Rigidbody2D rigi;

    private void Start()
    {
        if (ver) transform.localRotation = Quaternion.Euler(0, 0, 90);
        thePos = this.transform.position;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (key == 0) key = 1;
        rigi = other.gameObject.GetComponent<Rigidbody2D>();
        if (rigi != null)
        {
            if (ver)
            {
                rigi.velocity = Vector2.zero;
                rigi.AddForce(new Vector2(0, winFor * key * Time.deltaTime));
            }
            else
            {
                rigi.velocity = Vector2.zero;
                rigi.AddForce(new Vector2(winFor * key * Time.deltaTime, 0));
            }
        }
    }

    private void FixedUpdate()
    {
        if (key == 0) key = 1;
        if (roop)
        {
            if (ver)
            {
                if (transform.position.y <= winRan2)
                {
                    transform.position += new Vector3(0, winSpeed * key * Time.deltaTime, 0);
                }
                else if (transform.position.y >= winRan2)
                {
                    transform.position = new Vector3(thePos.x, winRan1, 0);
                }
            }
            else
            {
                if (transform.position.x <= winRan2)
                {
                    transform.position += new Vector3(winSpeed * key * Time.deltaTime, 0, 0);
                }
                else if (transform.position.x >= winRan2)
                {
                    transform.position = new Vector3(winRan1, thePos.y, 0);
                }
            }
        }
        else
        {
            if (ver)
            {
                if (transform.position.y <= winRan1) key = 1;
                else if (transform.position.y >= winRan2) key = -1;

                transform.position += new Vector3(0, winSpeed * key * Time.deltaTime, 0);
            }
            else
            {
                if (transform.position.x <= winRan1) key = 1;
                else if (transform.position.x >= winRan2) key = -1;

                transform.position += new Vector3(winSpeed * key * Time.deltaTime, 0, 0);
            }
        }
    }
}
