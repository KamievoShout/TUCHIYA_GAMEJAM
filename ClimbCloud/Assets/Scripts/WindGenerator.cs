using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindGenerator : MonoBehaviour
{
    [Tooltip("���I�u�W�F�N�g")]
    [SerializeField] private GameObject Wind;
    private GameObject wind;

    [Tooltip("�d�C�G�l���M�[�̍ő�l")]
    [SerializeField] private float ThunderGauge;
    [Tooltip("�d�C�G�l���M�[�̎��R�񕜒l")]
    [SerializeField] private float ThunderStock;
    [Tooltip("���̏���d�C�Q�[�W")]
    [SerializeField] private float ThunderCost;
    private float NowThunder;

    [Tooltip("�d�C�Q�[�W�̃X���C�_�[UI")]
    [SerializeField] Slider ThunderSlider;

    [Tooltip("�_�̃X�N���v�g")]
    [SerializeField] CloudGenerator cloud;

    [Tooltip("�_�𐶐����Ă��邩�ǂ���")]
    public bool CloudGene;
    void Start()
    {
        NowThunder = ThunderGauge;
        ThunderSlider.value = 1;
    }

    void Update()
    {
        //�d�C��
        NowThunder += ThunderStock;
        if (NowThunder >= ThunderGauge)
        {
            NowThunder = ThunderGauge;
        }
        ThunderSlider.value = NowThunder / ThunderGauge;

        //������
        if (Input.GetMouseButtonDown(1)&&ThunderCost <= NowThunder&&CloudGene == false)
        {
            wind = Instantiate(Wind, gameObject.transform.position, Quaternion.identity);
        }
        if (Input.GetMouseButton(1) && ThunderCost <= NowThunder&&wind)
        {
            wind.transform.position = gameObject.transform.position + new Vector3(0, 4, 0);
            cloud.CloudMove = false;
            NowThunder -= ThunderCost;
            cloud.WindGene = true;
        }
        if (Input.GetMouseButtonUp(1) || ThunderCost >= NowThunder)
        {
            if (wind)
            {
                Destroy(wind);
            }
            cloud.WindGene = false;
        }
        Vector3 ThunderPos = ThunderSlider.transform.position;
        ThunderPos.x = gameObject.transform.position.x;
        ThunderSlider.transform.position = ThunderPos;
    }
}
