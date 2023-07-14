using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utility;
using Utility.Audio;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Image[] numberImages;
    [SerializeField] private Sprite[] numberSprites;

    public void Active(int maxPos)
    {
        gameObject.SetActive(true);

        int normalize = maxPos / 32;
        Debug.Log(normalize);
        int digits = normalize.ToString().Length;
        for(int i = 0; i < numberImages.Length;i++)
        {
            bool isActive = i <= digits - 1;
            numberImages[i].gameObject.SetActive(isActive);
            if (isActive)
            {
                int num = int.Parse(normalize.ToString()[i].ToString());
                numberImages[i].sprite = numberSprites[num];
            }
        }
        Locator<IPlayAudio>.Resolve().PlaySE("GameOver");
        Locator<IPlayAudio>.Resolve().PlayBGMFade(null, 0.5f);
    }

    public void Retry()
    {
        SceneManager.LoadSceneAsync("Game");
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadSceneAsync("Title");
    }
}
