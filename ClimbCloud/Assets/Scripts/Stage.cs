using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField]
    private GameObject flagObj;

    void Start()
    {
        
    }

    /// <summary>
    /// 旗の座標を返す
    /// </summary>
    public Vector2 GetFlagPos()
    {
        return flagObj.transform.position;
    }
}
