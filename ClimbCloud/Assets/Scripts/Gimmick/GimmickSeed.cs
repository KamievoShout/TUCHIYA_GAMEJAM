using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class GimmickSeed : MonoBehaviour
{
    private GimmickKinds gimmickKind;

    void Start()
    {
        MakeGimmickKind();
    }

    /// <summary>
    /// �M�~�b�N�̎�ނ����߂�
    /// </summary>
    private void MakeGimmickKind()
    {
        int enumLength = Enum.GetValues(typeof(GimmickKinds)).Length;
        int seendNum = UnityEngine.Random.Range(0, enumLength);
        gimmickKind = (GimmickKinds)Enum.ToObject(typeof(GimmickKinds), seendNum);
    }

    /// <summary>
    /// �M�~�b�N�̎�ނ��擾����
    /// </summary>
    public GimmickKinds GetGimmickKindType()
    {
        gimmickKind = GimmickKinds.BlackOut;
        return gimmickKind;
    }
}
