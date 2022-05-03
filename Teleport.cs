using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Usable
{
 /*   protected override void Awake()
    {
        base.Awake();
        itemName = "Teleport";
    }
 */
    public void Transport()
    {
        Player.Instance.transform.position = Vector3.zero + Vector3.up * 3;
    }
}
