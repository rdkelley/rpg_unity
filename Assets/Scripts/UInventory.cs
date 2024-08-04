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

    [SerializeField] Inventory playerInventory;
    [SerializeField] Player player;

    Dictionary<string, GameObject> uItemVariants = new Dictionary<string, GameObject>();
    Dictionary<string, Item> itemConsumable = new Dictionary<string, Item>();

    void Start()
    {
        playerInventory.onAddItem += Add;

        uItemVariants.Add("PotionHealth", uPotionHPrefab);
        uItemVariants.Add("PotionMana", uPotionMPrefab);
        uItemVariants.Add("Sword", uSwordPrefab);

        itemConsumable.Add("PotionHealth", healthPotion);
        itemConsumable.Add("PotionMana", manaPotion);
    }

    public void UseItem(string item)
    {
        itemConsumable[item].Use(player);
    }

    void Add(Enums item)
    {
        Debug.Log("ITEM ADDED: " + item.ToString());

        GameObject slot = Instantiate(uItemVariants[item.ToString()], inventoryPanel.transform);

        // Set slot properties like position, icon, etc.
        slot.GetComponent<UItem>().Set(item);
    }
}