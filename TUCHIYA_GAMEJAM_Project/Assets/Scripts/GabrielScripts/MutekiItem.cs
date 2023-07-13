using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutekiItem : ItemBase
{
    public override Item PowerUp()
    {
        return Item.Muteki;
    }
}
