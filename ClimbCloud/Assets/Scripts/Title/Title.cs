using UnityEngine;
using Utility;
using Utility.Audio;

public class Title : MonoBehaviour
{
    private void Start()
    {
        Locator<IPlayAudio>.Resolve().PlayBGMFade("Title", 1);
    }
}
