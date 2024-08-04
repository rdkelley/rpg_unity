using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Consumable : Item
{
    public override void Use(Player player)
    {
        Debug.Log("USE CALLED" + player);
        var notifier = player.Get<Notifier>(attribute) as Notifier;
        notifier.Add(Amount);
    }
}
