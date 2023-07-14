using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private bool isShake = false;

    /// <summary>
    /// ��ʂ�h�炷
    /// </summary>
    /// <param name="duration">����</param>
    /// <param name="magnitude">����</param>
    public void Shake(float duration, float magnitude)
    {
        if(isShake)
        {
            return;
        }

        StartCoroutine(DoShake(duration, magnitude));
    }

    private IEnumerator DoShake(float duration, float magnitude)
    {
        isShake = true;

        var pos = transform.localPosition;

        var elapsed = 0f;

        while (elapsed < duration)
        {
            var x = pos.x + Random.Range(-1f, 1f) * magnitude;
            var y = pos.y + Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, pos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = pos;

        isShake = false;
    }
}
