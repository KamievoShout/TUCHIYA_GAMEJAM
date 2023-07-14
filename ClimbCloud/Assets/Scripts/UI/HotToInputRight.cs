using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotToInputRight : MonoBehaviour
{
    [SerializeField]
    private Image upKeyImage;

    [SerializeField]
    private Image leftKeyImage;

    [SerializeField]
    private Image rightKeyImage;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            upKeyImage.color = Color.gray;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            upKeyImage.color = Color.white;
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            leftKeyImage.color = Color.gray;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            leftKeyImage.color = Color.white;
        }


        if (Input.GetKey(KeyCode.RightArrow))
        {
            rightKeyImage.color = Color.gray;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            rightKeyImage.color = Color.white;
        }
    }
}
