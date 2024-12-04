using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpgrade : Upgrade
{
    public float speedIncrease;

    public SpeedUpgrade(Rarity rarity, float speedIncrease) : base(rarity)
    {
        this.speedIncrease = speedIncrease;
    }

    public override void ApplyUpgrade(GameObject target)
    {
        // Apply the upgrade
    }
}
