using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float xpGain, maxHp, maxMana, maxXp, baseStr, baseDef, baseInt;
    [SerializeField] public Attribute strength, defense, intelligence, hp, mana, xp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
