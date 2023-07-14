using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float lerp = 0;
    [SerializeField]
    private float offsetY;

    void Start()
    {

        

    }
    
    void Update()
    {

        
        Vector3 playerPos = this.player.transform.position;
        float posY = Mathf.Lerp(transform.position.y, playerPos.y + offsetY, Time.deltaTime * lerp);
        //transform.position = new Vector3(transform.position.x, playerPos.y, transform.position.z);
        transform.position = new Vector3(transform.position.x, posY , transform.position.z);
    }
}
