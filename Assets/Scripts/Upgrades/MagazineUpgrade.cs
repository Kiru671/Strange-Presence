using UnityEngine;

namespace Upgrades
{
    [CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrades/Magazine Upgrade")]
    public class MagazineUpgrade : Upgrade
    {
        public override void ApplyUpgrade(GameObject target, RarityHelper.Rarity rarity)
        {
            var weapon = target.GetComponentInChildren<Weapon>();
            if (weapon != null) weapon.magSize += Mathf.RoundToInt(multipliers[(int)rarity]* 0.01f * weapon.magSize);
            else Debug.LogError("MagazineUpgrade can only be applied to Weapon");
        }
    }
}