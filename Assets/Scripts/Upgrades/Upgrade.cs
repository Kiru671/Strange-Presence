using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade : ScriptableObject
{
    public string[] upgradeNames;
    protected string finalName;
    public string description;
    public Rarity rarity;
    
    public abstract void ApplyUpgrade(GameObject target);
    
    public enum Rarity
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary
    }

    protected Upgrade(Rarity rarity)
    {
        this.rarity = rarity;
    }
    
}
