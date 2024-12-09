using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Upgrades;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrades/FireRateUpgrade", order = 2)]
public class FireRateUpgrade : Upgrade
{
    public override void ApplyUpgrade(GameObject target, UpgradeManager.Rarity rarity)
    {
        Debug.Log("FireRateUpgrade");
    }
}
