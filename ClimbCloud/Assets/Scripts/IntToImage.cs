using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntToImage : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> numSpriteList = new List<Sprite>();

    /// <summary>
    /// 数字をSpriteに変換して配列で返す
    /// </summary>
    /// <param name="num">数字</param>
    /// <param name="digits">桁数</param>
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
    /// 指定した桁の数字を取り出す
    /// </summary>
    /// <param name="num">数値</param>
    /// <param name="digit">取り出したい桁</param>
    private int GetPointDigit(int num, int digit)
    {
        return (int)(num / Mathf.Pow(10, digit - 1)) % 10;
    }
}
