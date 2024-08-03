using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public Texture2D icon;
    public Action<Item> OnUse;
    public GameObject worldPrefab;
    [SerializeField] float amount;
    public float Amount => amount;
    [SerializeField] protected Attribute attribute;
    public Attribute Attribute => attribute;
    public abstract void Use(Player player); 

}
