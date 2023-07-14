using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloudGenerator : MonoBehaviour
{
    CapsuleCollider2D cap;

    [Tooltip("小曇")]
    [SerializeField] private GameObject CloudS;
    [Tooltip("中の曇")]
    [SerializeField] private GameObject CloudM;
    [Tooltip("大曇")]
    [SerializeField] private GameObject CloudL;

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
    [Tooltip("小雲の消費水ゲージ")]
    [SerializeField] private float WaterCostS;
    [Tooltip("中雲の消費水ゲージ")]
    [SerializeField] private float WaterCostM;
    [Tooltip("大雲の消費水ゲージ")]
    [SerializeField] private float WaterCostL;
    private float NowWater;

    [Tooltip("雲を動かしたかどうか")]
    public bool CloudMove = false;

    [Tooltip("水ゲージのスライダーUI")]
    [SerializeField] Slider WaterSlider;

    [Tooltip("風を生成しているかどうか")]
    public bool WindGene;

    [Tooltip("風のスクリプト")]
    [SerializeField] WindGenerator wind;

    GameObject Cloud;
    float size = 0;
    float time;
    void Start()
    {
        cap = GetComponent<CapsuleCollider2D>();

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

        //雲生成
        Vector3 pos;
        pos = gameObject.transform.position + new Vector3(0, CloudPos, 0);
        if (Input.GetMouseButton(0)&&WindGene == false)
        {
            time += Time.deltaTime;
            if (size == 0 && NowWater >= WaterCostS && CloudMove == false)
            {
                Cloud = Instantiate(CloudS, pos, Quaternion.identity);
                size = 1;
                NowWater -= WaterCostS;
            }
            else if (GeneTimeM <= time && size == 1 && NowWater >= WaterCostM&&Cloud)
            {
                Destroy(Cloud);
                Cloud = Instantiate(CloudM, pos, Quaternion.identity);
                size = 2;
                NowWater -= WaterCostM;
            }
            else if (GeneTimeL <= time && size == 2 && NowWater >= WaterCostL&&Cloud)
            {
                Destroy(Cloud);
                Cloud = Instantiate(CloudL, pos, Quaternion.identity);
                size = 3;
                NowWater -= WaterCostL;
            }
            if (Cloud)
            {
                Cloud.transform.position = pos;
            }
            CloudMove = true;
            wind.CloudGene = true;
        }
        //曇完成
        if (Input.GetMouseButtonUp(0))
        {
            time = 0;
            size = 0;
            Cloud = null;
            wind.CloudGene = false;
        }


        Vector3 WaterPos = WaterSlider.transform.position;
        WaterPos.x = gameObject.transform.position.x;
        WaterSlider.transform.position = WaterPos;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Rain"))
        {
            Debug.Log("当たり雨");
            NowWater += 1.0f;
        }
    }
}
