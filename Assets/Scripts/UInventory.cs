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

    [SerializeField] Item healthPotion;
    [SerializeField] Item manaPotion;
    [SerializeField] Item sword;

    [SerializeField] Inventory playerInventory;
    [SerializeField] Player player;

    Dictionary<string, GameObject> uItemVariants = new Dictionary<string, GameObject>();
    Dictionary<string, Item> usableItems = new Dictionary<string, Item>();

    void Start()
    {
        playerInventory.onAddItem += Add;

        uItemVariants.Add("PotionHealth", uPotionHPrefab);
        uItemVariants.Add("PotionMana", uPotionMPrefab);
        uItemVariants.Add("Sword", uSwordPrefab);

        usableItems.Add("PotionHealth", healthPotion);
        usableItems.Add("PotionMana", manaPotion);
        usableItems.Add("Sword", sword);
    }

    public void UseItem(string item)
    {
        usableItems[item].Use(player);
    }

    void Add(Enums item)
    {
        GameObject slot = Instantiate(uItemVariants[item.ToString()], inventoryPanel.transform);

        // Set slot properties like position, icon, etc.
        slot.GetComponent<UItem>().Set(item);
    }
}