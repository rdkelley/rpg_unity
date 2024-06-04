using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] Player player;

    [SerializeField] List<Enums> items = new List<Enums>();

    //public Action<Item> onAddItem, onUseItem, onRemoveItem;
    public void Add(Item item)
    {
        items.Add(item);
        Debug.Log(item);
        //onAddItem?.Invoke(item);
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        //onRemoveItem?.Invoke(item);
    }

    public void Use(Item item)
    {
        item.Use(player);
        //onUseItem?.Invoke(item);
    }
}