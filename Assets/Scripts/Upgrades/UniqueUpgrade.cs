using UnityEngine;

namespace Upgrades
{
    [CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrades/Unique Upgrade")]
    public class UniqueUpgrade : Upgrade
    {
        public override void ApplyUpgrade(GameObject target, Rarity rarity)
        {
            // Apply the upgrade
        }
    }
}
