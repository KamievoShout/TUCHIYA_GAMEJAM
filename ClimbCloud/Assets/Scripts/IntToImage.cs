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
