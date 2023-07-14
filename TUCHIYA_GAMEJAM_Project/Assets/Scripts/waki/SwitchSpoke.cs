using System.Collections.Generic;
using UnityEngine;

public class SwitchSpoke : SwitchObjectBase
{
    [SerializeField] List<GameObject> spikies = new List<GameObject>();
    public override void SwitchPushed()
    {
        for (int i = 0; i < spikies.Count; i++)
        {
            spikies[i].GetComponent<SpikeMove>().SpikeUpDown(true);
        }
    }



}
