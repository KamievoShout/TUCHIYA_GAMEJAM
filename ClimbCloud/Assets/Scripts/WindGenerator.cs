using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindGenerator : MonoBehaviour
{
    [Tooltip("風オブジェクト")]
    [SerializeField] private GameObject Wind;
    private GameObject wind;

    [Tooltip("電気エネルギーの最大値")]
    [SerializeField] private float ThunderGauge;
    [Tooltip("電気エネルギーの自然回復値")]
    [SerializeField] private float ThunderStock;
    [Tooltip("風の消費電気ゲージ")]
    [SerializeField] private float ThunderCost;
    private float NowThunder;

    [Tooltip("電気ゲージのスライダーUI")]
    [SerializeField] Slider ThunderSlider;
    void Start()
    {
        NowThunder = ThunderGauge;
        ThunderSlider.value = 1;
    }

    void Update()
    {
        NowThunder += ThunderStock;
        if (NowThunder >= ThunderGauge)
        {
            NowThunder = ThunderGauge;
        }
        ThunderSlider.value = NowThunder / ThunderGauge;

        if (Input.GetMouseButtonDown(1)&&ThunderCost <= NowThunder)
        {
            wind = Instantiate(Wind, gameObject.transform.position, Quaternion.identity);
        }
        if (Input.GetMouseButton(1) && ThunderCost <= NowThunder)
        {
            wind.transform.position = gameObject.transform.position + new Vector3(0, 4, 0);
            NowThunder -= ThunderCost;
        }
        if (Input.GetMouseButtonUp(1) || ThunderCost >= NowThunder)
        {
            if (wind)
            {
                Destroy(wind);
            }
        }
        Vector3 ThunderPos = ThunderSlider.transform.position;
        ThunderPos.x = gameObject.transform.position.x;
        ThunderSlider.transform.position = ThunderPos;
    }
}
