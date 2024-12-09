using UnityEngine;

namespace Upgrades
{
    [CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrades/Magazine Upgrade")]
    public class MagazineUpgrade : Upgrade
    {
        public override void ApplyUpgrade(GameObject target, UpgradeManager.Rarity rarity)
        {
            Debug.Log("MagazineUpgrade");
        }
        
    }
}