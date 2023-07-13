using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Utility.Audio
{
    public class AudioPlayer : MonoBehaviour, IPlayAudio, IAudioVolumeChange, IGetAudioVolume
    {
        [SerializeField] AudioMixer audioMixer = null;

        [SerializeField] AudioDatas bgmDatas = null;
        [SerializeField] AudioDatas seDatas = null;

        [SerializeField] AudioSource bgmSource = null;
        [SerializeField] AudioSource seSource = null;

        public void PlaySE(string name, float volume = 1)
        {
            seSource.volume = volume;
            seSource.PlayOneShot(seDatas.GetData(name).Clip);
        }

        public void PlayBGM(string name)
        {
            AudioData data = bgmDatas.GetData(name);
            if(string.IsNullOrEmpty(name))
            {
                bgmSource.clip = null;
            }
            else
			{
                bgmSource.clip = data.Clip;
                bgmSource.Play();
            }
        }

        public void PlayBGMFade(string name, float time)
        {
            if(string.IsNullOrEmpty(name))
            {
                StartCoroutine(BGMFade(name, time));
                return;
            }
            AudioData data = bgmDatas.GetData(name);
            if (data.Clip == bgmSource.clip) return;
            StartCoroutine(BGMFade(name, time));
        }

        private IEnumerator BGMFade(string name, float time)
        {
            float multiply = 1 / time;
            float nowTime = 1;
            while (0 < nowTime)
            {
                nowTime -= multiply * Time.deltaTime;
                bgmSource.volume = nowTime;
                yield return null;
            }
            bgmSource.volume = 1;
            PlayBGM(name);
        }

        public void ChangeMasterVolume(float volume)
        {
            audioMixer.SetFloat("Master_Volume", ConvertVolume2dB(volume));
        }

        public void ChangeBGMVolume(float volume)
        {
            audioMixer.SetFloat("BGM_Volume", ConvertVolume2dB(volume));
        }

        public void ChangeSEVolume(float volume)
        {
            audioMixer.SetFloat("SE_Volume", ConvertVolume2dB(volume));
        }

        public float GetMasterVolume()
        {
            float volume;
            audioMixer.GetFloat("Master_Volume", out volume);
            return Convert_dB2Volume(volume);
        }

        public float GetBGMVolume()
        {
            float volume;
            audioMixer.GetFloat("BGM_Volume", out volume);
            return Convert_dB2Volume(volume);
        }

        public float GetSEVolume()
        {
            float volume;
            audioMixer.GetFloat("SE_Volume", out volume);
            return Convert_dB2Volume(volume);
        }

        private float ConvertVolume2dB(float volume) => Mathf.Lerp(-80, 20, volume);
        private float Convert_dB2Volume(float dB) => (dB + 80) / 100f;

#if UNITY_EDITOR
        [MenuItem("CONTEXT/AudioPlayer/CreateAudioDatas")]
        private static void CreateBGM_Datas(MenuCommand menuCommand)
        {
            var audioPlayer = menuCommand.context as AudioPlayer;

            {
                AudioDatas bgmDatas = ScriptableObject.CreateInstance<AudioDatas>();
                string path = AssetDatabase.GenerateUniqueAssetPath("Assets/Plugins/AudioManager/BGM_Datas.asset");
                AssetDatabase.CreateAsset(bgmDatas, path);
                audioPlayer.bgmDatas = bgmDatas;
            }

            {
                AudioDatas seDatas = ScriptableObject.CreateInstance<AudioDatas>();
                string path = AssetDatabase.GenerateUniqueAssetPath("Assets/Plugins/AudioManager/SE_Datas.asset");
                AssetDatabase.CreateAsset(seDatas, path);
                audioPlayer.seDatas = seDatas;
            }
            

            AssetDatabase.Refresh();
        }
#endif
	}
}