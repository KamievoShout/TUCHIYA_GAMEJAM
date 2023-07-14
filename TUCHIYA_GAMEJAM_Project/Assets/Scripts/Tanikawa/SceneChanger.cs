using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField]
    private Dropdown selectDropdown;
    private Button sceneChangeButton;
    private void Awake()
    {
        sceneChangeButton = GetComponent<Button>();

        sceneChangeButton.onClick.AddListener(() => SceneChange());
    }

    private void SceneChange()
    {
        string selectScene = selectDropdown.captionText.text;
        SceneManager.LoadScene(selectScene);
    }
}
