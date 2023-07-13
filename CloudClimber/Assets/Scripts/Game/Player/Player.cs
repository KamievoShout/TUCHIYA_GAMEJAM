using PlayerInternal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    // プレイヤーを指定した高さでジャンプさせます
    public void Jump(float height)
    {
        mover.Jump(height);
    }

    // プレイヤーの移動を停止させます
    public void Stop()
    {
        mover.Stop();
    }

    // プレイヤーを指定した方向へノックバックします
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
