using UnityEngine;
using Utility;

[DefaultExecutionOrder(-1)]
public class GameOver : MonoBehaviour
{
    [SerializeField] private GameOverUI gameOverUI;

    private Transform playerTra;
    private float maxPos;

    private void Start()
    {
        PlayerController ctrl = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        ctrl.OnDead += () => gameOverUI.Active(Mathf.CeilToInt(maxPos));
        playerTra = GameObject.FindWithTag("Player").transform;
    }

	private void Update()
	{
        if (playerTra == null) return;
        if(playerTra.position.y > maxPos)
        {
            maxPos = playerTra.position.y;
        }
	}
}
