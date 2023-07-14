using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NowPosition : MonoBehaviour
{
    [SerializeField]
    Transform StartPos;
    [SerializeField]
    Transform GoalPos;
    [SerializeField]
    Transform PlayerPos;

    [SerializeField]
    Slider slider;

    private void Update()
    {
        //スタート、ゴール、プレイヤーpositionのY軸を取得し続ける
        float a = StartPos.position.y;
        float b = PlayerPos.position.y;
        float c = GoalPos.position.y;

        //プレイヤー - スタート
        float ba = b - a;
        //ゴール - スタート
        float ca = c - a;
        
        //割合
        float dir = ba / ca;

        //シリンダーに割合を入れる
        slider.value = dir;
        //Debug.Log(dir);
    }
}
