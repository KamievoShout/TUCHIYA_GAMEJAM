using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeightUI : MonoBehaviour
{

    public Text heightText;
    public Transform playerTransform;

    private void Update()
    {
        // プレイヤーの高さを取得し、UIのテキストを更新する
        float height = playerTransform.position.y;
        heightText.text = "高さ: " + height.ToString("F2");
    }
}
