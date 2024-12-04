using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateUpgrade : Upgrade
{
    public float fireRateIncrease;

    public FireRateUpgrade(Rarity rarity, float fireRateIncrease) : base(rarity)
    {
        this.fireRateIncrease = fireRateIncrease;
    }

    public override void ApplyUpgrade(GameObject target)
    {
        // Apply the upgrade
    }
    
}
