using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    // ������΂�����
    private int[] _directions = { 1, -1 };

    [SerializeField, Header("������΂��傫��"), Range(0, 3)]
    private float _addPower;

    /// <summary>
    /// ���������琁����΂�
    /// </summary>
    /// <param name="collision">���������I�u�W�F�N�g</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        int direction = _directions[Random.Range(0, 2)];

        rb.AddForce(new Vector2(direction, 0) * _addPower * 100);
    }
}
