using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Usable : Item
{
    /*
    protected override void Awake()
    {
        base.Awake();
        itemType = ItemType.Usable;
    }
    */
    protected override void GetItem()
    {
        ItemManager.Instance.AddItem(this);
    }
}
