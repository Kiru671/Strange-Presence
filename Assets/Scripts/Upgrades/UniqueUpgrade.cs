using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueUpgrade : Upgrade
{
    public string uniqueUpgradeName;
    public string uniqueUpgradeDescription;

    public UniqueUpgrade(Rarity rarity, string uniqueUpgradeName, string uniqueUpgradeDescription) : base(rarity)
    {
        this.uniqueUpgradeName = uniqueUpgradeName;
        this.uniqueUpgradeDescription = uniqueUpgradeDescription;
    }

    public override void ApplyUpgrade(GameObject target)
    {
        // Apply the upgrade
    }
}
