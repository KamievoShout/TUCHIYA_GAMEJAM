using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameData : ScriptableObject
{
    // クリアできたか？
    public bool IsCleared = false;

    // 残り時間
    public float TimeLeft = 0.0f;
}
