using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItemController : MonoBehaviour
{
    GameObject cat;

    void Start() {
        cat = GameObject.Find("cat");
    }

    void Update() {
        transform.position = cat.transform.position + new Vector3(0, 150, 0);
    }
}
