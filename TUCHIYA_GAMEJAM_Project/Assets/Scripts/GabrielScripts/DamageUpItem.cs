using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUpItem : ItemBase
{
    public override Item PowerUp()
    {
        return Item.DamageUpItem;
    }
}
