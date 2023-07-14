using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    public static SoundEffectManager instance;

    public AudioClip[] soundEffectClips; // 効果音の配列

    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }


        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// 指定されたインデックスの効果音を
    /// </summary>
    /// <param name="index">効果音のインデックス</param>
    public void PlaySoundEffect(int index)
    {
        if (index < 0 || index >= soundEffectClips.Length)
        {
            Debug.LogWarning("Invalid sound effect index: " + index);
            return;
        }
        audioSource.PlayOneShot(soundEffectClips[index]);
    }
}
