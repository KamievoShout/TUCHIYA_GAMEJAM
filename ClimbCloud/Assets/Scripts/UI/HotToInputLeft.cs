using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotToInputLeft : MonoBehaviour
{
    [SerializeField]
    private Image wKeyImage;

    [SerializeField]
    private Image aKeyImage;

    [SerializeField]
    private Image dKeyImage;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            wKeyImage.color = Color.gray;
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            wKeyImage.color = Color.white;
        }


        if (Input.GetKey(KeyCode.A))
        {
            aKeyImage.color = Color.gray;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            aKeyImage.color = Color.white;
        }


        if (Input.GetKey(KeyCode.D))
        {
            dKeyImage.color = Color.gray;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            dKeyImage.color = Color.white;
        }
    }
}
