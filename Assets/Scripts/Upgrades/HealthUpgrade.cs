using UnityEngine;

namespace Upgrades
{
    [CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrades/Health Upgrade")]
    public class HealthUpgrade : Upgrade
    {
        public override void ApplyUpgrade(GameObject target, RarityHelper.Rarity rarity)
        {
            var player = target.GetComponent<Player>();
            if (player != null)
            {
                player.maxHealth += multipliers[(int)rarity];
                player.health = player.maxHealth;
                player.HealthUpdate();
            }
            else Debug.LogError("HealthUpgrade can only be applied to Player.");
        }
        
    }
}
