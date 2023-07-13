using PlayerInternal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    // �v���C���[���w�肵�������ŃW�����v�����܂�
    public void Jump(float height)
    {
        mover.Jump(height);
    }

    // �v���C���[�̈ړ����~�����܂�
    public void Stop()
    {
        mover.Stop();
    }

    // �v���C���[���w�肵�������փm�b�N�o�b�N���܂�
    public void Knockback(float dir)
    {
        mover.Knockback(dir);
    }




    PlayerMover mover;
    private void Start()
    {
        mover = GetComponent<PlayerMover>();
    }
}
