using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    Ore,
    Fuel,
    Other
}
public abstract class Item : ScriptableObject
{
    public Type _Type;

    public string _Name;

    public bool _InShop;

    [Range(0f, 1000f)]
    public float _Value;
}

