using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : Item, IModifier
{
    public Enums set;
    //objects is a list of GameObjects that form the equipment
    public List<GameObject> objects;

    public static Dictionary<Enums, Equipment> active = new Dictionary<Enums, Equipment>();

    public override void Use(Player player)
    {
        if (active.ContainsKey(set))
        {
            //First deactivate the equipped equipment
            active[set].Unequip(player);

            //And update the active equipment
            active[set] = this;
        }
        else
            active.Add(set, this);
        //Then equip the new equipment
        Equip(player);
    }

    public virtual void Equip(Player player)
    {
        //Activate all GameObjects that form this equipment
        objects.ForEach(z => z.SetActive(true));
     
        var stat = player.Get<Stats>(attribute);
        if (stat != null)
            stat.AddModifier(this);
    }

    public virtual void Unequip(Player player)
    {
        objects.ForEach(z => z.SetActive(false));
        var stat = player.Get<Stats>(attribute);
        if (stat != null)
            stat.RemoveModifier(this);
    }
}
