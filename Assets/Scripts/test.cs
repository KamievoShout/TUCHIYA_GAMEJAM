using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    int testnum;
    int testold;
    // Start is called before the first frame update
    void Start()
    {
        testnum = Random.Range(0, 1000);

        testold = Testmsd(testnum);
    }

    int void Testmsd(int a)
    {
        Debug.Log(a);
        testold = a;
        return testold;
    }
}
