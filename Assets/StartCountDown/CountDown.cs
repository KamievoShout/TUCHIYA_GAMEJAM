using System.Collections;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    [SerializeField]
    TimeCounter timeCounter;
    int currentCount;
    public int Count => currentCount;

    bool isCounting = false;
    public bool IsCounting => isCounting;

    void Start()
    {
        if (isCounting) return;
        isCounting = true;
        StartCoroutine(CountDownCol(3));
    }

    IEnumerator CountDownCol(int count)
    {
        for (int i = count; i > 0; i--)
        {
            currentCount = i;
            yield return new WaitForSeconds(1);
        }
        isCounting = false;
        timeCounter.StartCount();
    }
}