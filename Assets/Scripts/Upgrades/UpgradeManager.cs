using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Upgrades;
using System;
using Bodardr.Databinding.Runtime;
using Random = UnityEngine.Random;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private GameObject[] upgradeCards;
    [SerializeField] private Upgrade[] allUpgrades;
    [SerializeField] private BindingCollectionBehavior bindingCollection;
    [SerializeField] private Player player;
    
    private TextMeshPro titleText;
    private TextMeshPro descriptionText;
    private List<Upgrade> availabeUpgrades = new List<Upgrade>();
    private UpgradeWithRarity[] selectedUpgrades;
    public static Action onUpgradeChosen;

    private void OnEnable()
    {
        availabeUpgrades.Clear();
        GenerateUpgradeChoices();
        availabeUpgrades.Clear();
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
            });
        }
    }
}
