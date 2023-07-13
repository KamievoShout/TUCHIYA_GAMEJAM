using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindUI : MonoBehaviour
{

    private Quaternion windDir;

    private RectTransform rctTrans;

    void Start()
    {
        rctTrans = GetComponent<RectTransform>();
    }


    void Update()
    {        
    }

    public void moveWind(float _moveDir)
    {
        this.transform.rotation = Quaternion.Euler(0, 0, _moveDir); 
        Debug.Log("movewind "+_moveDir);
    }
}
