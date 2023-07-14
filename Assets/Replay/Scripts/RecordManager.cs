using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordManager : MonoBehaviour
{
    [SerializeField]
    PlayerController player;
    [SerializeField]
    GameObject ghost;
    [SerializeField]
    Recorder recorder;
    [SerializeField]
    CountDown countDown;
    bool gameStart = false;

    void Update()
    {
        if (!countDown.IsCounting)
        {
            if (!gameStart)
            {
                recorder.StartRecord(player.gameObject);
                recorder.StartLoadLog(ghost);

                gameStart = true;
            }
        }

        if (player.isGoal)
        {
            if (gameStart)
            {
                recorder.EndRecord();
                recorder.StopLoadLog();
                gameStart = false;
            }
        }
        // デバッグ用
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.O))
        {
            recorder.EndRecord();
        }
#endif
    }
}