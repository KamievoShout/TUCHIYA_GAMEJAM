using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class TimerView : MonoBehaviour
    {
        Text text;

        [SerializeField]
        string formatText = "Žc‚èŽžŠÔ {0:F1}";

        private void Start()
        {
            text = GetComponent<Text>();
            var gameManager = FindFirstObjectByType<GameManager>();

            gameManager.ObserveEveryValueChanged(m => m.Timer)
                .Subscribe(time =>
                {
                    text.text = string.Format(formatText, time);
                });
        }
    }

}