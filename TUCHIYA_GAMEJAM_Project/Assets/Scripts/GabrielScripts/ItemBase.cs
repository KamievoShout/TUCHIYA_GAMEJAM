using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    public enum Item
    {
        SpeedUpItem,
        DamageUpItem,
        Muteki,
        Heal,
        Count,
    }

    public abstract Item PowerUp();
}

    

