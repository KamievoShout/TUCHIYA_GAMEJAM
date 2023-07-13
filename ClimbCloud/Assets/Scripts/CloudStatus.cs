using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudStatus : MonoBehaviour
{
    [SerializeField] int size = 3;   // 雲の大きさ
    [Tooltip("小・中・大の雲オブジェクト")]
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

    // 雲の大きさを大きくする処理
    public void plusSize(int value)
    {
        size += value;
    }
    // 雲の大きさを小さくする処理
    public void minusSize(int value)
    {
        size -= value;
    }
}
