using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    //[SerializeField] Player player;

    [SerializeField] List<Enums> items = new List<Enums>();

    public Action<Enums> onAddItem, onUseItem, onRemoveItem;

    public void Add(Enums item)
    {
        items.Add(item);
        Debug.Log(item);
        onAddItem?.Invoke(item);
    }

    public void Remove(Enums item)
    {
        items.Remove(item);
        //onRemoveItem?.Invoke(item);
    }

    //public void Use(Enums item)
    //{
    //    item.Use(player);
    //    //onUseItem?.Invoke(item);
    //}
}

