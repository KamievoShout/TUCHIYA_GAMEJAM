using UnityEngine;
using Utility;
using Utility.Audio;

public class BGMPlayer : MonoBehaviour
{
    [SerializeField] private string bgmName;

    private void Start()
    {
        Locator<IPlayAudio>.Resolve().PlayBGMFade(bgmName, 1);
    }
}
