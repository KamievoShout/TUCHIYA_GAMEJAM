using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class FallPillar : Gimmick
{
    [SerializeField, Header("柱のオブジェクト")]
    private GameObject _pillar;

    [SerializeField, Header("プレイヤーから離す距離")]
    private Vector2 _diffPosition;

    /// <summary>
    /// 柱を生成する
    /// </summary>
    /// <param name="playerPos">プレイヤーの現在座標</param>
    public void GeneratePillar(Vector2 playerPos)
    {
        Vector2 generatePos = playerPos + _diffPosition;
        Instantiate(_pillar, generatePos, Quaternion.identity);
    }

}
