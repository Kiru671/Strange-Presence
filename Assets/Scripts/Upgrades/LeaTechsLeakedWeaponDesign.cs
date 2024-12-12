using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Upgrades;

namespace Upgrades
{
    [CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrades/Unique_LeaTechsLeakedWeaponDesign", order = 99)]
    public class LeaTechsLeakedWeaponDesign : Upgrade
    {
        public override void ApplyUpgrade(GameObject target, RarityHelper.Rarity rarity)
        {
            var weapon = target.GetComponentInChildren<Weapon>();
            if (weapon != null)
            {
                weapon.bulletDMG *= multipliers[0] * 0.01f;
                weapon.fireRate *= multipliers[1] * 0.01f;
                weapon.isKnockbackEnabled = true;
            }
            else Debug.LogError("LeaTechsLeakedWeaponDesign can only be applied to Weapon");
        }
    }
}


