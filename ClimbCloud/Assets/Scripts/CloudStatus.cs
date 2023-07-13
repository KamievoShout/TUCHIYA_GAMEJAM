using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudStatus : MonoBehaviour
{
    [SerializeField] int size = 3;   // �_�̑傫��
    [Tooltip("���E���E��̉_�I�u�W�F�N�g")]
    [SerializeField] GameObject[] cloudObj = new GameObject[3];

    private void Update()
    {
        ChangeSize();
    }

    void ChangeSize()
    {
        for (int i = 0; i < cloudObj.Length; i++)
        {
            if (i == size - 1)
                cloudObj[i].SetActive(true);
            else
                cloudObj[i].SetActive(false);
        }
    }

    // �_�̑傫����傫�����鏈��
    public void plusSize(int value)
    {
        size += value;
    }
    // �_�̑傫�������������鏈��
    public void minusSize(int value)
    {
        size -= value;
    }
}
