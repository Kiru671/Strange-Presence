using System;
using System.Collections.Generic;
using System.Linq;
using Bodardr.Databinding.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Upgrades
{
    public class UpgradeManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] upgradeCards;
        [SerializeField] private Upgrade[] allUpgrades;
        [SerializeField] private BindingCollectionBehavior bindingCollection;
        [SerializeField] private Player player;
    
        private TextMeshPro titleText;
        private TextMeshPro descriptionText;
        private List<Upgrade> availabeUpgrades = new List<Upgrade>();
        private List<Upgrade> ownedUpgrades = new List<Upgrade>();
        private List<Upgrade> uniquePath = new List<Upgrade>();
        private UpgradeWithRarity[] selectedUpgrades;
        
        public static Action onUpgradeChosen;

        private void OnEnable()
        {
            availabeUpgrades.Clear();
            GenerateUpgradeChoices();
        }
    
        public void GenerateUpgradeChoices()
        {
            // Randomly select 3 upgrades
            selectedUpgrades = allUpgrades.OrderBy(x => Random.value).Take(3)
                .Select(x => new UpgradeWithRarity(x, RarityHelper.GetRandomRarity())).ToArray();
            bindingCollection.Collection = selectedUpgrades;

            for (int i = 0; i < selectedUpgrades.Length; i++)
            {
                int capturedIndex = i;
                upgradeCards[i].GetComponent<Button>().onClick.RemoveAllListeners();
                upgradeCards[i].GetComponent<Button>().onClick.AddListener(() =>
                {
                    onUpgradeChosen?.Invoke();
                    selectedUpgrades[capturedIndex].upgrade
                        .ApplyUpgrade(player.gameObject, selectedUpgrades[capturedIndex].rarity);
                    ownedUpgrades.Add(selectedUpgrades[capturedIndex].upgrade);
                    Debug.Log($"Current Upgrades: {string.Join(", ", ownedUpgrades.Select(x => x.name))}");
                });
            }
        }
    }
}