using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UItem : MonoBehaviour
{
    public string itemName;
    public Texture2D itemIcon;
    public Item item;

    UInventory uInventory;

    void Start()
    {
        GameObject inventoryObject = GameObject.FindWithTag("Inventory");

        uInventory = inventoryObject.GetComponent<UInventory>();
    }

    public void Set(Enums item)
    {
    }

    public void OnItemClick()
    {
        uInventory.UseItem(itemName);

        RemoveFromInventory();
    }

    void RemoveFromInventory()
    {
        Destroy(gameObject);
    }
}