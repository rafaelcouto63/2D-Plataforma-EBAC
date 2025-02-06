using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBaseCoin : CollectableBase
{
    private int amount = 1;
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.instance.AddCoin(amount);
    }
}
