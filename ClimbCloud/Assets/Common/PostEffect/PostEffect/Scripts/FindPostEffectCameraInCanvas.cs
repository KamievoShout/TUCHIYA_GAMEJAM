using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.PostEffect;

public class FindPostEffectCameraInCanvas : MonoBehaviour
{
    [SerializeField] RenderMode mode = RenderMode.ScreenSpaceCamera;

    private void Awake()
    {
        Canvas c = GetComponent<Canvas>();
        c.renderMode = mode;
        c.worldCamera = FindObjectOfType<PostEffectCamera>().GetComponent<Camera>();
    }
}
