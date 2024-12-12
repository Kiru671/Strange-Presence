using UnityEngine;

namespace  Upgrades
{
    [CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrades/FireRateUpgrade")]
    public class FireRateUpgrade : Upgrade
    {
        public override void ApplyUpgrade(GameObject target, RarityHelper.Rarity rarity)
        {
            var weapon = target.GetComponentInChildren<Weapon>();
            if (weapon != null) weapon.fireRate +=  multipliers[(int)rarity] * 0.01f * weapon.fireRate;
            else Debug.LogError("FireRateUpgrade can only be applied to Weapon");
        }
    }
}

