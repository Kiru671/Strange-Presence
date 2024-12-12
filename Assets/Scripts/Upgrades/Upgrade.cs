using UnityEngine;

namespace Upgrades
{
    public abstract class Upgrade : ScriptableObject
    {
        public string[] upgradeNames;
        public string description;
        public bool isUnique;
    
        public abstract void ApplyUpgrade(GameObject target, RarityHelper.Rarity rarity);
        public int[] multipliers;
    }
}
