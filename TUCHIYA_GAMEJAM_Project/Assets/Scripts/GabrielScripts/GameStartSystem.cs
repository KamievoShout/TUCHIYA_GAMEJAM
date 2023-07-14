using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEditorInternal.ReorderableList;

public class GameStartSystem : MonoBehaviour
{
    [SerializeField]
    GameObject parent;
    private float time;
    TextMeshProUGUI tmp;

    void Start()
    {
        Time.timeScale = 0; 
        tmp = GetComponent<TextMeshProUGUI>();
    }


    // Update is called once per frame
    void Update()
    {
        time += Time.fixedDeltaTime;
        Debug.Log(time);
        switch (time)
        {
            case < 1:
                tmp.text = "3"; break;
            case <4:
                tmp.text = "2"; break;
            case < 6:
                tmp.text = "1"; break;
            case < 8:
                tmp.text = "Go!!"; break;
            case < 10f:
                Debug.Log(parent);
                Time.timeScale = 1;
                Destroy(parent);break;
            default:
                Debug.Log("‚Ò‚á‚ŸI");break;
        }


    }
}
