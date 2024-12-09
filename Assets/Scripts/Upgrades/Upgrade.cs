using UnityEngine;

namespace Upgrades
{
    public abstract class Upgrade : ScriptableObject
    {
        public string[] upgradeNames;
        public string finalName;
        public string description;
    
        public abstract void ApplyUpgrade(GameObject target, UpgradeManager.Rarity rarity);

        public void SetName(UpgradeManager.Rarity rarity)
        {
            finalName = upgradeNames[(int)rarity];
        }
    }
}
