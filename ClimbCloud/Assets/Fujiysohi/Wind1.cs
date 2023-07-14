using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind1 : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject windUI;

    private WindUI windDirUI;

    private Vector2 plvec;

    // 風関係のタイマー
    private float windCtr = 0;
    public float windWait = 10;
    [SerializeField]
    private int windWhile = 3;
    // 風向き
    public float windDir = 0;
    private Vector2 windVec;

    private int windNo = 0;
  
    void Start()
    {     
        plvec = player.transform.position;
        windDirUI = windUI.GetComponent<WindUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //plvec = this.transform.position;
        //plvec += windVec;
        //this.transform.position = plvec;
        //windCtr += Time.deltaTime;
        //if (windCtr >= windWait)
        //{
        //    windDir = Random.Range(0, 181);
        //    windDirUI.moveWind(windDir);
        //    Debug.Log("windDir "+windDir);
        //    windVec = AngleToVector2(windDir);
        //    windCtr = 0;
        //}
    }

    public Vector3 WindVector()
    {
        switch (windNo)
        {
            case 0:
                windCtr += Time.deltaTime;
                windUI.SetActive(false);
                windVec = Vector3.zero;
                if (windCtr >= windWait)
                {
                    windDir = Random.Range(0, 181);
                    if (windDir >= 90)
                    {
                        windDir = 180;
                    }
                    else
                    {
                        windDir = 0;
                    }
                    windDirUI.moveWind(windDir);
                    Debug.Log("windDir " + windDir);
                    windUI.SetActive(true);
                    windVec = AngleToVector2(windDir);
                    windCtr = 0;
                    windNo++;
                }
                break;
            case 1:
                windCtr += Time.deltaTime;
                if (windCtr >= windWhile)
                { 
                    windCtr = 0;
                    windNo = 0; ;
                }
                break;

        }
        Debug.Log(windVec);
        return windVec * Time.deltaTime * 2;
    }


    // 角度からベクトルを計算
    public static Vector2 AngleToVector2(float angle)
    {
        var radian = angle * (Mathf.PI / 180);
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian)).normalized;
    }
}
