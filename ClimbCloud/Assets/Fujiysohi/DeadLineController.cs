using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLineController : MonoBehaviour
{
    [SerializeField] private float MoveForce = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0, MoveForce * Time.deltaTime, 0);
    }
}
