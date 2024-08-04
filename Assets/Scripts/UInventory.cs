using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UInventory : MonoBehaviour
{
    public List<UItem> items = new List<UItem>();
    public GameObject inventoryPanel;
    public GameObject uPotionHPrefab;
    public GameObject uPotionMPrefab;
    public GameObject uSwordPrefab;

    [SerializeField] Inventory playerInventory;
    [SerializeField] Player player;

    Dictionary<string, GameObject> itemVariants = new Dictionary<string, GameObject>();

    void Start()
    {
        playerInventory.onAddItem += Add;

        itemVariants.Add("Potion", uPotionHPrefab);
        itemVariants.Add("PotionM", uPotionMPrefab);
        itemVariants.Add("Sword", uSwordPrefab);
    }

    public void UseItem(Enums Item)
    {
        Debug.Log(Item.ToString());
    }

    void Add(Enums item)
    {
        Debug.Log("ITEM ADDED: " + item.ToString());

        GameObject slot = Instantiate(itemVariants[item.ToString()], inventoryPanel.transform);

        // Set slot properties like position, icon, etc.
        slot.GetComponent<UItem>().Set(item);
    }
}