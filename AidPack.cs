using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidPack : Usable
{
    [SerializeField]
    int healAmount = 300;
    /*
    protected override void Awake()
    {
        base.Awake();
        itemName = "AidPack";
    }
    */
    public void heal()
    {
        Player.Instance.health += healAmount;
        if (Player.Instance.health > Player.Instance.maxHealth)
        {
            Player.Instance.health = Player.Instance.maxHealth;
        }
        UIManager.Instance.HealthUIUpdate();
    }
}
