using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntToImage : MonoBehaviour
{
    [SerializeField]
    private List<Image> numImages = new List<Image>();


    public void ChangeImage(int num)
    {
        string numStr = num.ToString();
        int strLength = numStr.Length;
        for (int i = 0; i < strLength; i++)
        {

        }
    }
}
