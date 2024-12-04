using UnityEngine;

namespace Upgrades
{
    public class HealthUpgrade : Upgrade
    {
        public HealthUpgrade(Rarity rarity) : base(rarity)
        {
            
        }

        public override void ApplyUpgrade(GameObject target)
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
