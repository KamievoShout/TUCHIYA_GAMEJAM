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
    /// Šø‚ÌÀ•W‚ğ•Ô‚·
    /// </summary>
    public Vector2 GetFlagPos()
    {
        return flagObj.transform.position;
    }
}
