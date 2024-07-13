using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] CapsuleCollider _collider;

    public void Activate()
    {
        _collider.enabled = true;
    }

    public void Deactivate()
    {
        _collider.enabled = false;
    }

    //ICharacter is an interface that all game character inherit from
    [SerializeField] Player owner;

    private void OnValidate()
    {
        //We get a reference to the ICharacter by checking the parent GameObjects
        owner = GetComponentInParent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root == transform.root)
        {
            return;
        }

        var character = other.GetComponent<Player>();

        if (character)
        {
            character.ReceiveDmg(owner.TotalDmg);
        }

        //Deactivate the weapon to prevent damaging multiple times with one swing.


    }
}