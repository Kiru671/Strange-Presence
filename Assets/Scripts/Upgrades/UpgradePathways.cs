using UnityEngine;

namespace Upgrades
{
    public class UpgradePathways : MonoBehaviour
    {
        
        [SerializeField] private UniqueUpgradePool[] uniqueUpgradePools;
        
    }
    [System.Serializable]
    public class UniqueUpgradePool
    {
        [SerializeField] private string pathwayName;
        [SerializeField] private Upgrade[] upgrades;
    }
}