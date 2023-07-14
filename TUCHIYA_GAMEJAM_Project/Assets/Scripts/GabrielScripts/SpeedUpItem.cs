using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpItem : ItemBase
{
    public override Item PowerUp()
    {
        return Item.SpeedUpItem;
    }
}
