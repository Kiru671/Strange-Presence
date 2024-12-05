using UnityEngine;

namespace Upgrades
{
    [CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrades/Health Upgrade")]
    public class HealthUpgrade : Upgrade
    {
        public override void ApplyUpgrade(GameObject target, Rarity rarity)
        {
            // Example: Increase the health of the target
            var player = target.GetComponent<Player>();
            if (player != null)
            {
                player.health += 10;
            }
        }
        
    }
}
