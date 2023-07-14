using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeightUI : MonoBehaviour
{

    public Text heightText;
    public Transform playerTransform;

    private void Update()
    {
        // �v���C���[�̍������擾���AUI�̃e�L�X�g���X�V����
        float height = playerTransform.position.y;
        heightText.text = "����: " + height.ToString("F2");
    }
}