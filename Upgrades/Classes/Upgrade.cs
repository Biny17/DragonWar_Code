using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade : ScriptableObject
{
    public Sprite icon;
    [Multiline]
    public string description;
    public List<Upgrade> requirements;

    public abstract void ApplyUpgrade(GameObject player);
    public abstract string GetDescription(GameObject player);
}