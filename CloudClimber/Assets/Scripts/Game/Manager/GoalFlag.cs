using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class GoalFlag : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _))
        {
            MessageBroker.Default.Publish(new GoalEvent());
        }
    }
}
