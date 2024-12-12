using UnityEngine;

namespace Upgrades
{
    [CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrades/Unique_DiresVengeance", order = 99)]
    public class DiresVengeance : Upgrade
    {
        public override void ApplyUpgrade(GameObject target, RarityHelper.Rarity rarity)
        {
            var weapon = target.GetComponentInChildren<Weapon>();
            if (weapon != null)
            {
                weapon.bulletDMG *= multipliers[0] * 0.01f;
                weapon.diresVengeance = true;
            }
            else Debug.LogError("Electromagnetism can only be applied to Weapon");
        }
    }
}