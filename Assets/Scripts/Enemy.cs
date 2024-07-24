using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float xpGain, maxHp, maxMana, maxXp, baseStr, baseDef, baseInt;
    [SerializeField] public Attribute strength, defense, intelligence, hp, mana, xp;
    [SerializeField] Dictionary<Attribute, Wrapper> stats = new Dictionary<Attribute, Wrapper>();

    [SerializeField] Animator animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        stats.Add(strength, new Stats(baseStr));
        stats.Add(defense, new Stats(baseDef));
        stats.Add(intelligence, new Stats(baseInt));
        stats.Add(hp, new Notifier(maxHp, maxHp));
        stats.Add(mana, new Notifier(maxMana, maxMana));
        stats.Add(xp, new Notifier(0, maxXp));
    }

    public void ReceiveDmg(float damage)
    {
        var stat = Get<Notifier>(hp);
        stat.Add(Get<Stats>(defense).Total - damage);

        Debug.Log("Received " + damage + " damage");
        Debug.Log("New defense: " + Get<Stats>(defense).Total);

        animator.SetTrigger("React");
    }

    public void Sleep()
    {
        Debug.Log("Sleeping");
    }

    //All classes can use this function to access a character's wrappers
    //simply by referencing an attribute ScriptableObject 
    public T Get<T>(Attribute attribute) where T : Wrapper
    {
        if (!stats.ContainsKey(attribute))
            return null;
        return stats[attribute] as T;
    }
}
