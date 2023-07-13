using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadSceneAsync("Game");
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadSceneAsync("Title");
    }
}
