using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloudGenerator : MonoBehaviour
{
    [Tooltip("種曇")]
    [SerializeField] private GameObject SeedCloud;
    [Tooltip("小曇")]
    [SerializeField] private GameObject CloudS;
    [Tooltip("中の曇")]
    [SerializeField] private GameObject CloudM;
    [Tooltip("大曇")]
    [SerializeField] private GameObject CloudL;

    [Tooltip("小雲の生成時間")]
    [SerializeField] private float GeneTimeS;
    [Tooltip("中雲の生成時間")]
    [SerializeField] private float GeneTimeM;
    [Tooltip("大雲の生成時間")]
    [SerializeField] private float GeneTimeL;

    [Tooltip("マシンの上の雲の生成場所")]
    [SerializeField] private float CloudPos;

    [Tooltip("水エネルギーの最大値")]
    [SerializeField] private float WaterGauge;
    [Tooltip("水エネルギーの自然回復値")]
    [SerializeField] private float WaterStock;
    [Tooltip("種雲の消費水ゲージ")]
    [SerializeField] private float WaterCostF;
    [Tooltip("小雲の消費水ゲージ")]
    [SerializeField] private float WaterCostS;
    [Tooltip("中雲の消費水ゲージ")]
    [SerializeField] private float WaterCostM;
    [Tooltip("大雲の消費水ゲージ")]
    [SerializeField] private float WaterCostL;
    [SerializeField] private float NowWater;

    [Tooltip("水ゲージのスライダーUI")]
    [SerializeField] Slider WaterSlider;

    GameObject Cloud;
    float size = 0;
    float time;
    void Start()
    {
        size = 0;
        time = 0;
        NowWater = WaterGauge;
        WaterSlider.value = 1;
    }

    void Update()
    {
        //水回復
        NowWater += WaterStock;
        if (NowWater >= WaterGauge)
        {
            NowWater = WaterGauge;
        }
        WaterSlider.value = NowWater / WaterGauge;

        Vector3 pos;
        pos = gameObject.transform.position + new Vector3(0, CloudPos, 0);
        //曇生成
        if (Input.GetMouseButton(0))
        {
            time += Time.deltaTime;
            if (size == 0 && NowWater >= WaterCostF)
            {
                Cloud = Instantiate(SeedCloud, pos, Quaternion.identity);
                size = 1;
                NowWater -= WaterCostF;
            }
            else if (GeneTimeS <= time && size == 1 && NowWater >= WaterCostS)
            {
                Destroy(Cloud);
                Cloud = Instantiate(CloudS, pos, Quaternion.identity);
                size = 2;
                NowWater -= WaterCostS;
            }
            else if (GeneTimeM <= time && size == 2 && NowWater >= WaterCostM)
            {
                Destroy(Cloud);
                Cloud = Instantiate(CloudM, pos, Quaternion.identity);
                size = 3;
                NowWater -= WaterCostM;
            }
            else if (GeneTimeL <= time && size == 3 && NowWater >= WaterCostL)
            {
                Destroy(Cloud);
                Cloud = Instantiate(CloudL, pos, Quaternion.identity);
                size = 4;
                NowWater -= WaterCostL;
            }
            if (Cloud)
            {
                Cloud.transform.position = pos;
            }
        }
        //曇完成
        if (Input.GetMouseButtonUp(0))
        {
            time = 0;
            size = 0;
            Cloud = null;
        }


        Vector3 WaterPos = WaterSlider.transform.position;
        WaterPos.x = gameObject.transform.position.x;
        WaterSlider.transform.position = WaterPos;
    }
}
