using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.SceneManagement;

public struct AddTime
{
    public float time;
}

public struct GoalEvent
{

}

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float initialTime = 40.0f;

    [SerializeField]
    private GameData gameData;

    private float timer = 0.0f;
    public float Timer => timer;
    
    private void Awake()
    {
        timer = initialTime;
        MessageBroker.Default.Receive<AddTime>()
            .Subscribe(x => AddTime(x.time))
            .AddTo(this);

        MessageBroker.Default.Receive<GoalEvent>()
            .Where(_ => this.enabled)
            .Subscribe(_ => GameClear())
            .AddTo(this);
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer > 0.0f) return;

        timer = 0.0f;
        GameOver();
    }

    public void AddTime(float time)
    {
        timer += time;
    }

    public void GameOver()
    {
        gameData.IsCleared = false;
        gameData.TimeLeft = 0.0f;

        this.enabled = false;

        SceneManager.LoadScene("ClearScene");
    }

    public void GameClear()
    {
        gameData.IsCleared = true;
        gameData.TimeLeft = timer;

        this.enabled = false;
        SceneManager.LoadScene("ClearScene");
    }
}