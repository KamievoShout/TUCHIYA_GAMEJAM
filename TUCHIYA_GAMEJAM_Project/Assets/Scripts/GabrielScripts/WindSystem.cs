using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditorInternal.ReorderableList;

public class WindSystem : MonoBehaviour
{
    [SerializeField, Header("風の与える力（addforce）")]
    private float winFor = 10;
    [SerializeField, Header("風の移動速度(vector)")]
    private float winSpeed = 5;
    [SerializeField, Header("風の移動範囲１，２(必ず２を大きくする)")]
    private float winRan1 = -1;
    [SerializeField]
    private float winRan2 = 5;
    [SerializeField,Header("縦移動はtrue ※ななめ移動は実装していないです")]
    private bool ver = false;
    [SerializeField,Header("一方通行にしたいならtrue")]
    private bool roop = false;
    [SerializeField,Header("動く方向１か-１"),Range(-1,1)]
    private int key =1;

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
        if((rigi = other.gameObject.GetComponent<Rigidbody2D>()) != null)
        {
            if (ver)
            {
                rigi.AddForce(new Vector2(0, winFor * key*Time.deltaTime));
            }
            else
            {
                rigi.AddForce(new Vector2(winFor*key*Time.deltaTime,0));
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
                if (transform.position.y < winRan2)
                {
                    transform.position += new Vector3(0, winSpeed * key * Time.deltaTime, 0);
                }
                else if (transform.position.y > winRan2)
                {
                    transform.position = new Vector3(thePos.x, winRan1, 0);
                }
            }
            else
            {
                if (transform.position.x < winRan2)
                {
                    transform.position += new Vector3(winSpeed * key * Time.deltaTime, 0, 0);
                }
                else if (transform.position.x > winRan2)
                {
                    transform.position = new Vector3(winRan1, thePos.y, 0);
                }
            }
        }
        else
        {
            if (ver)
            {
                if (transform.position.y < winRan1) key = 1;
                else if (transform.position.y > winRan2) key = -1;

                transform.position += new Vector3(0, winSpeed * key * Time.deltaTime, 0);
            }
            else
            {
                if (transform.position.x < winRan1) key = 1;
                else if (transform.position.x > winRan2) key = -1;

                transform.position += new Vector3(winSpeed * key * Time.deltaTime, 0, 0);
            }
        }
    }
}
