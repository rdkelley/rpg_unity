using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UItem : MonoBehaviour
{
    public string itemName;
    public Texture2D itemIcon;
    public Item item;
    // Add other properties as needed

    public void Set(Enums item)
    {
    }

    public void UseItem(Player player)
    {
        item.Use(player);
    }
}