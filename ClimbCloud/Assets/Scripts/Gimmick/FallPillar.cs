using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class FallPillar : Gimmick
{
    [SerializeField, Header("���̃I�u�W�F�N�g")]
    private GameObject _pillar;

    [SerializeField, Header("�v���C���[���痣������")]
    private float _diffPosition;

    /// <summary>
    /// ���𐶐�����
    /// </summary>
    /// <param name="playerPos">�v���C���[�̌��ݍ��W</param>
    public void GeneratePillar(Vector2 playerPos)
    {
        Vector2 generatePos = new Vector2(playerPos.x, playerPos.y + _diffPosition);
        Instantiate(_pillar, generatePos, Quaternion.identity);
    }

}
