using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : ItemBase
{
    public override Item PowerUp()
    {
        return Item.Goal;
    }
}
