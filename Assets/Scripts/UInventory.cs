using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UInventory : MonoBehaviour
{
    public List<UItem> items = new List<>();
    public GameObject inventoryPanel;
    public GameObject uItemPrefab;

    void Add(Item item)
    {
        GameObject slot = Instantiate(uItemPrefab, inventoryPanel.transform);
        // Set slot properties like position, icon, etc.
        slot.GetComponent<UItem>().Set(item);
    }
}

}