using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item
{
    public override void Use(Player player)
    {
        Debug.Log("USE RAN");
        var notifier = player.Get<Notifier>(attribute) as Notifier;
        notifier.Add(Amount);
    }
}
