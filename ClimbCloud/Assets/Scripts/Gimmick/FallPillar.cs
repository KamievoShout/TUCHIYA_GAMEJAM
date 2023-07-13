using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPillar : Gimmick
{
    [SerializeField, Header("柱のオブジェクト")]
    private GameObject _pillar;

    [SerializeField, Header("プレイヤーのTransform")]
    private Transform _playerTransform;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Instantiate(_pillar, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

}
