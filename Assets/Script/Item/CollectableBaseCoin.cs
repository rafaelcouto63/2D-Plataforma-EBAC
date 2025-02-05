using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBaseCoin : CollectableBase
{
    public int amount = 1;
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.instance.AddCoin(amount);
    }
}
