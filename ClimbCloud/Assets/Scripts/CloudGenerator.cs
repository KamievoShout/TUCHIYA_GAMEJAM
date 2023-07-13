using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloudGenerator : MonoBehaviour
{
    [Tooltip("���")]
    [SerializeField] private GameObject SeedCloud;
    [Tooltip("����")]
    [SerializeField] private GameObject CloudS;
    [Tooltip("���̓�")]
    [SerializeField] private GameObject CloudM;
    [Tooltip("���")]
    [SerializeField] private GameObject CloudL;

    [Tooltip("���_�̐�������")]
    [SerializeField] private float GeneTimeS;
    [Tooltip("���_�̐�������")]
    [SerializeField] private float GeneTimeM;
    [Tooltip("��_�̐�������")]
    [SerializeField] private float GeneTimeL;

    [Tooltip("�}�V���̏�̉_�̐����ꏊ")]
    [SerializeField] private float CloudPos;

    [Tooltip("���G�l���M�[�̍ő�l")]
    [SerializeField] private float WaterGauge;
    [Tooltip("���G�l���M�[�̎��R�񕜒l")]
    [SerializeField] private float WaterStock;
    [Tooltip("��_�̏���Q�[�W")]
    [SerializeField] private float WaterCostF;
    [Tooltip("���_�̏���Q�[�W")]
    [SerializeField] private float WaterCostS;
    [Tooltip("���_�̏���Q�[�W")]
    [SerializeField] private float WaterCostM;
    [Tooltip("��_�̏���Q�[�W")]
    [SerializeField] private float WaterCostL;
    [SerializeField] private float NowWater;

    [Tooltip("���Q�[�W�̃X���C�_�[UI")]
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
        //����
        NowWater += WaterStock;
        if (NowWater >= WaterGauge)
        {
            NowWater = WaterGauge;
        }
        WaterSlider.value = NowWater / WaterGauge;

        Vector3 pos;
        pos = gameObject.transform.position + new Vector3(0, CloudPos, 0);
        //�ܐ���
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
        //�܊���
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
