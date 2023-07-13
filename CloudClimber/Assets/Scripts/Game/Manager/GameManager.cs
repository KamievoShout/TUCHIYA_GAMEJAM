using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public struct AddTime
{
    public float time;
}

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float initialTime = 40.0f;

    private float timer = 0.0f;

    public float Timer => timer;
    
    private void Awake()
    {
        timer = initialTime;
        MessageBroker.Default.Receive<AddTime>()
            .Subscribe(x => AddTime(x.time))
            .AddTo(this);
    }

    private void Update()
    {
        timer -= Time.deltaTime;
    }

    public void AddTime(float time)
    {
        timer += time;
    }
}