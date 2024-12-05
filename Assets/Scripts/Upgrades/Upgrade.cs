using UnityEngine;

namespace Upgrades
{
    public abstract class Upgrade : ScriptableObject
    {
        public string[] upgradeNames;
        protected string finalName;
        public string description;
    
        public abstract void ApplyUpgrade(GameObject target, Rarity rarity);
    
        public enum Rarity
        {
            Common,
            Uncommon,
            Rare,
            Epic,
            Legendary
        }
    }
}
