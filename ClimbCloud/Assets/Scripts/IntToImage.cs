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
        int numDisits = num.ToString().Length;
        int disitsDiff = Mathf.Abs(digits - numDisits);

        Sprite[] sprites = new Sprite[digits];
        for (int i = 1; i <= digits; i++)
        {
            if(disitsDiff > 0 && (i + 1) <= disitsDiff)
            {
                sprites[i - 1] = numSpriteList[0];
                continue;
            }
            int digitNum = GetPointDigit(num, i);
            sprites[i - 1] = numSpriteList[digitNum];
        }
        return sprites;
    }

    /// <summary>
    /// �w�肵�����̐��������o��
    /// </summary>
    /// <param name="num">���l</param>
    /// <param name="digit">���o��������</param>
    private int GetPointDigit(int num, int digit)
    {
        return (int)(num / Mathf.Pow(10, digit - 1)) % 10;
    }
}
