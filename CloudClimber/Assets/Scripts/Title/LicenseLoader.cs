using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LicenseLoader : MonoBehaviour
{
    private Text text;
    private void Awake()
    {
        text = GetComponent<Text>();
        StartCoroutine(LoadTextAsync());
    }

    private IEnumerator LoadTextAsync()
    {
        var license = Resources.LoadAsync<TextAsset>("License");
        yield return license;

        text.text = (license.asset as TextAsset).text;
    }
}
