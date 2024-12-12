using UnityEngine;

namespace Upgrades
{
    public abstract class Upgrade : ScriptableObject
    {
        public string[] upgradeNames;
        public string description;
        public int[] multipliers;
        public bool isUnique;
    
        public abstract void ApplyUpgrade(GameObject target, RarityHelper.Rarity rarity);
        
    }
}
