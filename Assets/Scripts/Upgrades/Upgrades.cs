using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    [SerializeField] private GameObject[] upgradeCards;
    private TextMeshPro titleText;
    private TextMeshPro descriptionText;
    [SerializeField] private Player player;
    private List<Upgrade> availabeUpgrades = new List<Upgrade>();
    private List<string> selectedUpgrades = new List<string>();
    private List<GameObject> borderImages = new List<GameObject>();
    private Image[] upgradeImages;

    public Upgrade[] upgrades = new Upgrade[]
    {
        new Upgrade{Title = "Agile Hands", Rarity = "Common", Description = "Reload speed is faster by X%", Increase = 25, Reocurring = true},
        new Upgrade{Title = "Hasty Reflexes", Rarity = "Rare", Description = "Reload speed is faster by X%", Increase = 50, Reocurring = true},
        new Upgrade{Title = "0 Delay Neural Enhancements", Rarity = "Epic", Description = "Reload speed is faster by X%", Increase = 100, Reocurring = false},
        new Upgrade{Title = "Rocket Assisted Gloves by LeaTech", Rarity = "Legendary", Description = "Reload speed is faster by X%", Increase = 250, Reocurring = false},

        new Upgrade{Title = "Deep Mags", Rarity = "Common", Description = "Your magazines have X% more ammunition.", Increase = 30, Reocurring = true},
        new Upgrade{Title = "Deeper Mags", Rarity = "Rare", Description = "Your magazines have X% more ammunition.", Increase = 75, Reocurring = true},
        new Upgrade{Title = "Bottomless Mags", Rarity = "Epic", Description = "Your magazines have X% more ammunition.", Increase = 150, Reocurring = false},
        new Upgrade{Title = "Pocket Dimension", Rarity = "Legendary", Description = "Your magazines have X% more ammunition.", Increase = 300, Reocurring = false},

        new Upgrade{Title = "Sturdiness", Rarity = "Common", Description = "Your base health is increased by X", Increase = 25, Reocurring = true},
        new Upgrade{Title = "Light Armor", Rarity = "Rare", Description = "Your base health is increased by X", Increase = 50, Reocurring = true},
        new Upgrade{Title = "Indomitability", Rarity = "Epic", Description = "Your base health is increased by X", Increase = 125, Reocurring = false},
        new Upgrade{Title = "Hit me. I said hit me!", Rarity = "Legendary", Description = "Your base health is increased by X", Increase = 175, Reocurring = false},

        new Upgrade{Title = "Light on Feet", Rarity = "Common", Description = "You move X% faster", Increase = 15, Reocurring = true},
        new Upgrade{Title = "Athlete", Rarity = "Rare", Description = "You move X% faster", Increase = 25, Reocurring = true},
        new Upgrade{Title = "Quick, graceful movements", Rarity = "Epic", Description = "You move X% faster", Increase = 40, Reocurring = false},
        new Upgrade{Title = "The speed to evade tax- I mean, rockets.", Rarity = "Legendary", Description = "You move X% faster", Increase = 75, Reocurring = false},

        new Upgrade{Title = "Light on Feet", Rarity = "Common", Description = "Your weapon fires X% faster.", Increase = 15, Reocurring = true},
        new Upgrade{Title = "Athlete", Rarity = "Rare", Description = "Your weapon fires X% faster.", Increase = 25, Reocurring = true},
        new Upgrade{Title = "Quick, graceful movements", Rarity = "Epic", Description = "Your weapon fires X% faster.", Increase = 40, Reocurring = false},
        new Upgrade{Title = "Thermodynamics? Never heard of 'em.", Rarity = "Legendary", Description = "Your weapon fires X% faster.", Increase = 125, Reocurring = false},


        new Upgrade{Title = "Electromagnetism", Rarity = "Unique", Description = "Experience Orbs are attracted to you.", Reocurring = false},
        new Upgrade{Title = "Dire's Vengeance", Rarity = "Unique", Description = "Your rifle now shoots in a spread out pattern with X% reduced damage.", UpgradeType = "Assault Rifle", Increase = 15, Reocurring = false},
        new Upgrade{Title = "Dire's Vengeance", Rarity = "Unique", Description = "Your rifle now deals twice the damage and knocks back enemies. Reduces firerate by 50%", UpgradeType = "Assault Rifle", Increase = 2, Reocurring = false},


        /*new Upgrade{Title = "Attack"},
        new Upgrade{Title = "Attack"},
        new Upgrade{Title = "Attack"},
        new Upgrade{Title = "Attack"},
        new Upgrade{Title = "Piercing Bullets"}*/
    };

    void Start()
    {
        availabeUpgrades.Clear();
    }

    private void OnEnable()
    {
        // List 3 upgrades on screen when enabled. List 3 uniques playerLevel % 5 = 0. List 3 weapons at first.
        if(borderImages != null)
        {
            for (int i = 0; i < borderImages.Count(); i++)
            {
                borderImages[i].SetActive(false);
            }
        }
        borderImages.Clear();
        availabeUpgrades.Clear();
        ChooseUpgrades();
        ListUpgrades();
    }

    void Update()
    {
        
    }
    public class Upgrade
    {
        public string Title { get; set; }
        public float Increase { get; set; }
        public string Description { get; set; }
        public string UpgradeType { get; set; }
        public string Rarity { get; set; }
        public bool Reocurring { get; set; }
        public float Bias {get; set;}

    }

    public float GetRarityBias(string rarity)
    {
        switch (rarity)
        {
            case "Common":
                return 5f;
            case "Rare":
                return 3f;
            case "Epic":
                return 2f;
            case "Legendary":
                return 0.2f;
            case "Unique":
                return 1f;
            default:
                return 1f;
        }
    }

    public void ChooseUpgrades()
    {
        List<float> weights = new List<float>();
        float totalWeight = 0f;


        foreach (Upgrade upgrade in upgrades)
        {
            float weight = GetRarityBias(upgrade.Rarity);
            weights.Add(weight);
            totalWeight += weight;
        }

        for (int i = 0; i < 3; i++)
        {
            float randomValue = Random.Range(0, totalWeight);
            float cumulativeWeight = 0f;

            for (int j = 0; j < upgrades.Length; j++)
            {
                cumulativeWeight += weights[j];
                if (randomValue <= cumulativeWeight)
                {
                    if (upgrades[j].Reocurring == false && selectedUpgrades.Contains(upgrades[j].Title))
                    {
                        continue;
                    }

                    if (upgrades[j].Rarity == "Legendary" || upgrades[j].Rarity == "Epic" || upgrades[j].Rarity == "Unique")
                        selectedUpgrades.Add(upgrades[j].Title);

                    availabeUpgrades.Add(upgrades[j]);
                    totalWeight -= weights[j];
                    weights[j] = 0f;
                    break;
                }
            }
        }      
    }

    public void ListUpgrades()
    {
        //Enable rarity borders, add to array to disable on next OnEnable()
        for (int i = 0; i < availabeUpgrades.Count; i++)
        {
            GameObject usedImage = transform.GetChild(i).Find($"Border{availabeUpgrades[i].Rarity}").gameObject;
            usedImage.SetActive(true);
            borderImages.Add(usedImage);
            Debug.Log(usedImage);
        }

        //Set the title text
        for (int i = 0; i < availabeUpgrades.Count; i++)
        {
            transform.GetChild(i).GetComponent<Transform>().GetChild(0).GetComponent<TextMeshProUGUI>().text = availabeUpgrades[i].Title;
        }

        //Set description text
        for (int i = 0; i < availabeUpgrades.Count; i++)
        {
            transform.GetChild(i).GetComponent<Transform>().GetChild(1).GetComponent<TextMeshProUGUI>().text = availabeUpgrades[i].Description.Replace("X", availabeUpgrades[i].Increase.ToString());
        }
    }

    public void UpgradeChosen(string upgradeChosen)
    {
        switch (upgradeChosen)
        {
            case "Agile Hands":

                break;
        }
        this.enabled = false;
    }
}
