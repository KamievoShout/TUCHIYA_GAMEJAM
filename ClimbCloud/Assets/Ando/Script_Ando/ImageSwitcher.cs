using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSwitcher : MonoBehaviour
{
    public Sprite[] images;  // 切り替える画像の配列
    public Image imageComponent;  // 画像を表示するUI Imageコンポーネント

    private int currentIndex = 0;  // 現在の画像インデックス

    private void Start()
    {
        // 最初の画像を表示する
        if (images.Length > 0)
        {
            imageComponent.sprite = images[currentIndex];
        }
    }

    public void SwitchImage(bool next)
    {
        // 画像を切り替える
        switch (next)
        {
            case true:  // 次の画像
                currentIndex = (currentIndex + 1) % images.Length;
                break;
            case false:  // 前の画像
                currentIndex = (currentIndex - 1 + images.Length) % images.Length;
                break;
        }
        imageComponent.sprite = images[currentIndex];
    }
}
