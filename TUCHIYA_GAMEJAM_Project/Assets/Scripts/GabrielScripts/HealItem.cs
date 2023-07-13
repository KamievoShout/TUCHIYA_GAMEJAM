using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : ItemBase
{
    public override Item PowerUp()
    {
        return Item.Heal;
    }
}
