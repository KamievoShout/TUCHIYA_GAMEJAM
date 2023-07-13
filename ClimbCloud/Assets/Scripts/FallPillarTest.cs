using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPillarTest : MonoBehaviour
{
    [SerializeField]
    private GameObject pillarG;


    [SerializeField]
    private GameObject player;

    private FallPillar f;
    void Start()
    {
        f = pillarG.GetComponent<FallPillar>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            f.GeneratePillar(player.transform.position);
        }
    }
}
