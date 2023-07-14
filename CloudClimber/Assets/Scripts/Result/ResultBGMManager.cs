using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultBGMManager : MonoBehaviour
{
    [SerializeField]
    GameData data;

    [SerializeField]
    AudioClip clearBGM;

    [SerializeField]
    AudioClip missBGM;

    void Awake()
    {
        var source = GetComponent<AudioSource>();
        source.clip = data.IsCleared ? clearBGM : missBGM;
        source.Play();
    }
}
