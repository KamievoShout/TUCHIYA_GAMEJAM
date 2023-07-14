using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloudGenerator : MonoBehaviour
{
    [Tooltip("����")]
    [SerializeField] private GameObject CloudS;
    [Tooltip("���̓�")]
    [SerializeField] private GameObject CloudM;
    [Tooltip("���")]
    [SerializeField] private GameObject CloudL;

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
    [Tooltip("���_�̏���Q�[�W")]
    [SerializeField] private float WaterCostS;
    [Tooltip("���_�̏���Q�[�W")]
    [SerializeField] private float WaterCostM;
    [Tooltip("��_�̏���Q�[�W")]
    [SerializeField] private float WaterCostL;
    private float NowWater;

    [Tooltip("�_�𓮂��������ǂ���")]
    public bool CloudMove = false;

    [Tooltip("���Q�[�W�̃X���C�_�[UI")]
    [SerializeField] Slider WaterSlider;

    [Tooltip("���𐶐����Ă��邩�ǂ���")]
    public bool WindGene;

    [Tooltip("���̃X�N���v�g")]
    [SerializeField] WindGenerator wind;

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

        //�_����
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
        //�܊���
        if (Input.GetMouseButtonUp(0))
        {
            time = 0;
            size = 0;
            Cloud = null;
            wind.CloudGene = false;
        }


        //Vector3 WaterPos = WaterSlider.transform.position;
        //WaterPos.x = gameObject.transform.position.x;
        //WaterSlider.transform.position = WaterPos;
    }
}
