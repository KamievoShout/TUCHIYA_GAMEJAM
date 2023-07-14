using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class GimmickSeed : MonoBehaviour
{
    private CircleCollider2D collider2D;
    private SpriteRenderer spriteRenderer;
    private GimmickKinds gimmickKind;

    void Start()
    {
        collider2D = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        MakeGimmickKind();
    }

    /// <summary>
    /// ギミックの種類を決める
    /// </summary>
    private void MakeGimmickKind()
    {
        int enumLength = Enum.GetValues(typeof(GimmickKinds)).Length;
        int seendNum = UnityEngine.Random.Range(0, enumLength);
        gimmickKind = (GimmickKinds)Enum.ToObject(typeof(GimmickKinds), seendNum);
    }

    /// <summary>
    /// ギミックの種類を取得する
    /// </summary>
    public GimmickKinds GetGimmickKindType()
    {
        //gimmickKind = GimmickKinds.Pillar;
        return gimmickKind;
    }

    /// <summary>
    /// ギミックを一時的に使用不可能にする
    /// </summary>
    public void HideGimmick()
    {
        collider2D.enabled = false;
        spriteRenderer.enabled = false;
        StartCoroutine(WaitGimmickRevival());
    }

    private IEnumerator WaitGimmickRevival()
    {
        yield return new WaitForSeconds(GimmickStaticData.SEED_REVIVAL_TIME);
        collider2D.enabled = true;
        spriteRenderer.enabled = true;
    }
}
