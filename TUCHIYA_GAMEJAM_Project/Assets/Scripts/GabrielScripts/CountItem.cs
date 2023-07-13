using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountItem : ItemBase
{
    public override Item PowerUp()
    {
        return Item.Count;
    }
}
