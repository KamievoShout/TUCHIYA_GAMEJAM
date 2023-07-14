using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntToImage : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> numSpriteList = new List<Sprite>();

    /// <summary>
    /// ������Sprite�ɕϊ����Ĕz��ŕԂ�
    /// </summary>
    /// <param name="num">����</param>
    /// <param name="digits">����</param>
    public Sprite[] GetSprites(int num, int digits)
    {
        string numStr = num.ToString().PadLeft(digits, '0');
        Sprite[] sprites = new Sprite[digits];
        for (int i = 0; i < digits; i++)
        {
            char c = numStr[i];
            int n = int.Parse(c.ToString());
            sprites[i] = numSpriteList[n];
        }
        return sprites;
    }
}
