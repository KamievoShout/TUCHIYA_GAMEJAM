using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecorderTester : MonoBehaviour
{
    [SerializeField]
    Recorder recorder;
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject ghost;
    [SerializeField]
    bool recording = true;
    [SerializeField]
    bool loading = true;

    private void Start()
    {
        if (recording)
        {
            recorder.StartRecord(player);
        }
        if (loading)
        {
            recorder.StartLoadLog(ghost);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            recorder.EndRecord();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            recorder.StopLoadLog();
        }
    }
}