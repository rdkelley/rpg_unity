using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeReference]
    [SerializeField] Enums item;

    private void OnTriggerEnter(Collider other)
    {
        var inventory = other.GetComponentInChildren<Inventory>();
        if (inventory)
        {
            inventory.Add(item);
            Destroy(gameObject);
        }
    }
}
