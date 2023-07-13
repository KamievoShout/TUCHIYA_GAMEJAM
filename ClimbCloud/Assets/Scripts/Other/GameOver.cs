using UnityEngine;
using Utility;

[DefaultExecutionOrder(-1)]
public class GameOver : MonoBehaviour
{
    [SerializeField] private GameOverUI gameOverUI;
    private void Start()
    {
        PlayerController ctrl = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        ctrl.OnDead += gameOverUI.Active;
    }
}
