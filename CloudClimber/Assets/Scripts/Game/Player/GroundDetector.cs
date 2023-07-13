using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GroundDetector : MonoBehaviour
{
    [Header("判定位置")]
    [SerializeField]
    private Vector2 footPosition = new Vector2(0.0f, -1.0f);

    [Header("判定サイズ")]
    [SerializeField]
    private Vector2 collisionSize = new Vector2(0.5f, 0.05f);

    [Header("対象レイヤー")]
    [SerializeField]
    private LayerMask groundLayer;

    private double cacheTiming = -1;
    private RaycastHit2D hit2dCache;

    private RaycastHit2D[] cacheResult = new RaycastHit2D[4];

    private void Reset()
    {
        groundLayer = LayerMask.NameToLayer("Ground");
    }

    public bool IsGrounded()
    {
        if (cacheTiming == Time.timeAsDouble)
            return hit2dCache;

        cacheTiming = Time.timeAsDouble;
        hit2dCache = CheckGround();
        return hit2dCache;
    }

    private RaycastHit2D CheckGround()
    {
        Vector2 castStart = (Vector2)transform.position + footPosition + new Vector2(0f, collisionSize.y);
        float distance = collisionSize.y;

        int count = Physics2D.BoxCastNonAlloc(castStart, collisionSize, 0f, Vector2.down, cacheResult, distance, groundLayer);

        for (int i = 0; i < count; i++)
        {
            if (cacheResult[i].distance > 0.0f)
            {
                return cacheResult[i];
            }
        }
        return default;
    }


#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        var hit = CheckGround();
        Gizmos.DrawWireCube((Vector2)transform.position + footPosition, collisionSize);

        if (hit)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(hit.point, 0.1f);
        }
    }
#endif
}
