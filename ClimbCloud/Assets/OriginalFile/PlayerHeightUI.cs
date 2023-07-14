using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeightUI : MonoBehaviour
{

    public Text heightText;
    public Transform playerTransform;

    public static float height;

    private void Update()
    {
        // プレイヤーの高さを取得し、UIのテキストを更新する
        height = playerTransform.position.y;
        heightText.text = "高さ: " + height.ToString("F2");
    }
}
