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
        if (playerTransform != null)
        {
            // �v���C���[�̍������擾���AUI�̃e�L�X�g���X�V����
            RespawnController.instance.height = playerTransform.position.y;
            heightText.text = "����: " + RespawnController.instance.height.ToString("F2");
        }
    }
}
