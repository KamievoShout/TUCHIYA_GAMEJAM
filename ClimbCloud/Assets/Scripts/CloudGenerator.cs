using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloudGenerator : MonoBehaviour
{
    [Tooltip("éÌì‹")]
    [SerializeField] private GameObject SeedCloud;
    [Tooltip("è¨ì‹")]
    [SerializeField] private GameObject CloudS;
    [Tooltip("íÜÇÃì‹")]
    [SerializeField] private GameObject CloudM;
    [Tooltip("ëÂì‹")]
    [SerializeField] private GameObject CloudL;

    [Tooltip("è¨â_ÇÃê∂ê¨éûä‘")]
    [SerializeField] private float GeneTimeS;
    [Tooltip("íÜâ_ÇÃê∂ê¨éûä‘")]
    [SerializeField] private float GeneTimeM;
    [Tooltip("ëÂâ_ÇÃê∂ê¨éûä‘")]
    [SerializeField] private float GeneTimeL;

    [Tooltip("É}ÉVÉìÇÃè„ÇÃâ_ÇÃê∂ê¨èÍèä")]
    [SerializeField] private float CloudPos;

    [Tooltip("êÖÉGÉlÉãÉMÅ[ÇÃç≈ëÂíl")]
    [SerializeField] private float WaterGauge;
    [Tooltip("êÖÉGÉlÉãÉMÅ[ÇÃé©ëRâÒïúíl")]
    [SerializeField] private float WaterStock;
    [Tooltip("éÌâ_ÇÃè¡îÔêÖÉQÅ[ÉW")]
    [SerializeField] private float WaterCostF;
    [Tooltip("è¨â_ÇÃè¡îÔêÖÉQÅ[ÉW")]
    [SerializeField] private float WaterCostS;
    [Tooltip("íÜâ_ÇÃè¡îÔêÖÉQÅ[ÉW")]
    [SerializeField] private float WaterCostM;
    [Tooltip("ëÂâ_ÇÃè¡îÔêÖÉQÅ[ÉW")]
    [SerializeField] private float WaterCostL;
    [SerializeField] private float NowWater;

    [Tooltip("êÖÉQÅ[ÉWÇÃÉXÉâÉCÉ_Å[UI")]
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
        //êÖâÒïú
        NowWater += WaterStock;
        if (NowWater >= WaterGauge)
        {
            NowWater = WaterGauge;
        }
        WaterSlider.value = NowWater / WaterGauge;

        Vector3 pos;
        pos = gameObject.transform.position + new Vector3(0, CloudPos, 0);
        //ì‹ê∂ê¨
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
        //ì‹äÆê¨
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
