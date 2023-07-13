using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    // ������΂�����
    private int[] _directions = { 1, -1 };

    [SerializeField, Header("������΂��傫��"), Range(0, 3)]
    private float _addPower;

    private void Update()
    {
        // �J�����O�ɍs�����玩�g������
        if (!GetComponent<SpriteRenderer>().isVisible)
        {
            Destroy(gameObject);
        }
    }

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



    //���̃I�u�W�F�N�g��GameView�݂̂ŕ`�悳��Ă��邩����p�ɁA
    void OnWillRenderObject()
    {

#if UNITY_EDITOR

        // Debug.LogError("isVisible:::::camera:" + Camera.current.name);

        if (Camera.current.name != "SceneCamera" && Camera.current.name != "Preview Camera")
        {
        }
#endif
    }
}
