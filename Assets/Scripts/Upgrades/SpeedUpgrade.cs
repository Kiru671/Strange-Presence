using UnityEngine;

namespace Upgrades
{
    [CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrades/SpeedUpgrade", order = 1) ]
    public class SpeedUpgrade : Upgrade
    {
        public override void ApplyUpgrade(GameObject target, Rarity rarity)
        {
            // Apply the upgrade
        }
    }
}
