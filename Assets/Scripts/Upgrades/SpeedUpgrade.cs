using UnityEngine;

namespace Upgrades
{
    [CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrades/SpeedUpgrade") ]
    public class SpeedUpgrade : Upgrade
    {
        public override void ApplyUpgrade(GameObject target, RarityHelper.Rarity rarity)
        {
            var player = target.GetComponent<Player>();
            if (player != null) player.moveSpeed += multipliers[(int)rarity] * 0.01f * player.moveSpeed;
            else Debug.LogError("SpeedUpgrade can only be applied to Player");
        }
    }
}
