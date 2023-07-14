using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utility;
using Utility.Audio;
using Utility.PostEffect;

namespace Buttons
{
    [RequireComponent(typeof(Button))]
    public class StartGame : MonoBehaviour
    {
        [SerializeField] private float fadeTime = 0.5f;
        [SerializeField] private Color color = Color.black;
        [SerializeField] private PostEffectType fadeID;

        private bool isClick = false;

        private void Start()
        {
            Button button = GetComponent<Button>();
            button.onClick.AddListener(() => StartCoroutine(OnClickStartGame()));
        }

        public IEnumerator OnClickStartGame()
        {
            if (isClick) yield break;
            isClick = true;
            Locator<IPlayAudio>.Resolve().PlaySE("StartGame");
            new PostEffector().Fade(fadeID, fadeTime, color, PostEffector.FadeType.Out);
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadSceneAsync("Game");
        }
    }
}
