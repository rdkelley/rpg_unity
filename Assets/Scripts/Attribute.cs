
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

//[CreateAssetMenu(fileName = "Attribute", menuName = "ScriptableObjects/Attribute", order = 2)]
//public class Attribute : ScriptableObject
//{
//    public int HP = 100;
//    public int MP = 10;
//    public int Strength = 50;
//    public int Intelligence = 70;
//    public int Defense = 40;

//    public override string ToString()
//    {
//        return name;
//    }
//}