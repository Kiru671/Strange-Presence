using UnityEngine;

namespace Upgrades
{
    [CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrades/Reload Upgrade")]
    public class ReloadUpgrade : Upgrade
    {
        public override void ApplyUpgrade(GameObject target, RarityHelper.Rarity rarity)
        {
            var weapon = target.GetComponentInChildren<Weapon>();
            if (weapon != null) weapon.reloadSpeed -= multipliers[(int)rarity] * 0.01f * weapon.reloadSpeed;
            else Debug.LogError("ReloadUpgrade can only be applied to Weapon");
        }
    }
}
