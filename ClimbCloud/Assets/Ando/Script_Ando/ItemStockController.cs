using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemStockController : MonoBehaviour
{
    public bool rocketLaunch = false; 

    string itemName;

    //ここからUI関係
    public Sprite[] images;  // 切り替える画像の配列
    public Image imageComponent;  // 画像を表示するUI Imageコンポーネント
    //private int currentIndex = 0;  // 現在の画像インデックス
    private void Start()
    {
       imageComponent.sprite = images[0];
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // アイテムとの衝突を検出
        GameObject item = collision.gameObject;
        // アイテムのタグを読み取る
        string itemTag = item.tag;

        // タグに基づいて処理を行う
        switch (itemTag)
        {
            case "zero":
                imageComponent.sprite = images[0];
                Debug.Log("何もない");
                break;
            case "Rocket":
                imageComponent.sprite = images[1];
                itemName = "ロケット";
                // 追加の処理を追記
                break;
            case "Umbrella":
                imageComponent.sprite = images[2];
                itemName = "傘";
                // 追加の処理を追記
                break;
        }



        if (collision.CompareTag("Rocket") || collision.CompareTag("Umbrella"))
        {
            // アイテムオブジェクトを削除する
            Destroy(collision.gameObject);
        }
    }
    public void Update()
    {
        //imageComponent.sprite = images[currentIndex];
        if (Input.GetKeyDown(KeyCode.Z) && itemName == "ロケット")
        {

            SoundEffectManager.instance.PlaySoundEffect(5);
            rocketLaunch = true;
            itemName = "zero";
            imageComponent.sprite = images[0];
        }
        Debug.Log(itemName + "が使えます!");
    }
}
