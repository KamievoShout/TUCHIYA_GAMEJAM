using Utility.Audio;
using Utility.LoadScene;
using Utility.PostEffect;
using UnityEngine;

namespace Utility
{
    [DefaultExecutionOrder(-10)]
    public class Mappings : MonoBehaviour
    {
        [SerializeField] AudioPlayer audioPlayer = null;
        [SerializeField] PostEffectCamera postEffectCamera = null;
        [SerializeField] PostEffectMaterialDB materialDB = null;


        private void Awake()
        {
            if (GameObject.FindObjectsOfType<Mappings>().Length > 1) 
            {
                Destroy(gameObject);
                Debug.Log("OK");
                return;
			}

            Locator<IPlayAudio>.Register(audioPlayer);
            Locator<IAudioVolumeChange>.Register(audioPlayer);
            Locator<IGetAudioVolume>.Register(audioPlayer);

            Locator<IGetMaterialData>.Register(materialDB);
            Locator<IPostEffectCamera>.Register(postEffectCamera);

            new PostEffector().Fade(PostEffectType.SimpleFade, 1, Color.black, PostEffector.FadeType.In);
            DontDestroyOnLoad(gameObject);
        }
	}
}