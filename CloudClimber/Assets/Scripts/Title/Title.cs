using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class Title : MonoBehaviour
{
    [SerializeField]
    private ButtonEventTrigger startButton;

    [SerializeField]
    private ButtonEventTrigger quitButton;

    [SerializeField]
    private ButtonEventTrigger licenseButton;

    [SerializeField]
    private GameObject licensePanel;

    [SerializeField]
    private ButtonEventTrigger panelCloseButton;

   
    void Start()
    {
        ButtonController.SetCurrent(startButton);
        licensePanel.SetActive(false);
        licensePanel.transform.localScale = Vector3.zero;

        startButton.Clicked
            .Subscribe(_ =>
            {
                SceneManager.LoadScene("GameScene");
            }).AddTo(this);

        quitButton.Clicked
            .Subscribe(_ =>
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
            }).AddTo(this);


        licenseButton.Clicked
            .Subscribe(_ =>
            {
                licensePanel.SetActive(true);
                licensePanel.transform.DOScale(1.0f, 0.4f).SetEase(Ease.OutBack).SetLink(licensePanel);
                ButtonController.SetCurrent(panelCloseButton);
            }).AddTo(this);

        panelCloseButton.Clicked
            .Subscribe(_ =>
            {
                licensePanel.transform.DOScale(0.0f, 0.4f)
                .SetEase(Ease.InBack)
                .OnComplete(() => licensePanel.SetActive(false))
                .SetLink(licensePanel);
                ButtonController.SetCurrent(licenseButton);
            }).AddTo(this);
    }
}
