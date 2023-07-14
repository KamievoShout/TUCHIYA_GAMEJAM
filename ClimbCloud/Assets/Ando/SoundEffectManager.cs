using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    public static SoundEffectManager instance;

    public AudioClip[] soundEffectClips; // ���ʉ��̔z��

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
    /// �w�肳�ꂽ�C���f�b�N�X�̌��ʉ���
    /// </summary>
    /// <param name="index">���ʉ��̃C���f�b�N�X</param>
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
