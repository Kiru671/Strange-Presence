using UnityEngine;

namespace Upgrades
{
    [CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrades/Unique_Electromagnetism", order = 99)]
    public class Electromagnetism : Upgrade
    {
        public override void ApplyUpgrade(GameObject target, RarityHelper.Rarity rarity)
        {
            var player = target?.GetComponent<Player>();
            if (player != null) player.magnetic = true;
            else Debug.LogError("Electromagnetism can only be applied to Player");
        }
    }
}


