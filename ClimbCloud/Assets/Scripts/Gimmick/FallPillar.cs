using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPillar : Gimmick
{
    [SerializeField, Header("���̃I�u�W�F�N�g")]
    private GameObject _pillar;

    [SerializeField, Header("�v���C���[��Transform")]
    private Transform _playerTransform;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Instantiate(_pillar, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

}
