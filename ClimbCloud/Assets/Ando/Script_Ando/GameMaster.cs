using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{

    //public Text timerText;
    public Timer timer;

    public int situation =0;
    public void SwitchCase()
    {
        switch (situation)
        {
            case 0:
                timer.StartTimer();
                break;
            case 1:
                timer.StopTimer();
                break;
            default:
                Debug.Log("Invalid value");
                break;
        }
    }
}
