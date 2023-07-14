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
        if (playerTransform != null)
        {
            // プレイヤーの高さを取得し、UIのテキストを更新する
            RespawnController.instance.height = playerTransform.position.y;
            heightText.text = "高さ: " + RespawnController.instance.height.ToString("F2");
        }
    }
}
