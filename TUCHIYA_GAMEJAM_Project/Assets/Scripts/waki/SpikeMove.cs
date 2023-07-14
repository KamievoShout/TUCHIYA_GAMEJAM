using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMove : MonoBehaviour
{
    public float speed = 1f;
    public float initY;
    public float ofsetY = 0.5f;
    public bool spikeUp;

    public void SpikeUpDown(bool a)
    {
        spikeUp = a;
    }


    // Start is called before the first frame update
    void Start()
    {
        initY = transform.position.y;
        SpikeUpDown(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (spikeUp == true)
        {
            if (transform.position.y < initY + ofsetY)
            {
                transform.Translate(0, speed * Time.deltaTime, 0);
            }

        }
        else
        {
            if (transform.position.y >= initY)
            {
                transform.Translate(0, -1 * speed * Time.deltaTime, 0);
            }
        }
    }
}
