using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float baseStr, baseDef, baseInt;
    [SerializeField] Attribute strength, defense, intelligence;

    [SerializeField] Dictionary<Attribute, Wrapper> stats = new Dictionary<Attribute, Wrapper>();

    public T Get<T>(Attribute attribute) where T : Wrapper
    {
        if (!stats.ContainsKey(attribute))
            return null;
        return stats[attribute] as T;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
