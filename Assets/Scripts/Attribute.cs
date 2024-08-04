
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Attribute", menuName = "ScriptableObjects/Attribute", order = 2)]
public class Attribute : ScriptableObject
{
    public event Action onChange;

    public override string ToString()
    {
        return name;
    }
}