using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Upgrades;
using System;
using Random = UnityEngine.Random;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private GameObject[] upgradeCards;
    [SerializeField] private Upgrade[] allUpgrades;
    [SerializeField] private TextMeshProUGUI[] cardTitles;
    [SerializeField] private TextMeshProUGUI[] cardDescs;
    //private Weapon weapon;
    private TextMeshPro titleText;
    private TextMeshPro descriptionText;
    [SerializeField] private Player player;
    private List<Upgrade> availabeUpgrades = new List<Upgrade>();
    private Upgrade[] selectedUpgrades = new Upgrade[] { };
    private List<GameObject> borderImages = new List<GameObject>();
    public static Action onUpgradeListed;
    public static Action onUpgradeChosen;

    void Start()
    {
        /*availabeUpgrades.Clear();
        weapon = player.transform.GetChild(0).GetComponent<Weapon>();
        */
    }
    public void GenerateUpgradeChoices()
    {
        // Randomly select 3 upgrades
        selectedUpgrades = allUpgrades.OrderBy(x => Random.value).Take(3).ToArray();

        for (int i = 0; i < selectedUpgrades.Length; i++)
        {
            selectedUpgrades[i].SetName(Rarity.Common);
            
            cardTitles[i].text = selectedUpgrades[i].finalName;
            cardDescs[i].text = selectedUpgrades[i].description;
            onUpgradeListed?.Invoke();
            int index = i; // Capture current index for button callback

            // Attach ApplyUpgrade to each card button
            upgradeCards[i].GetComponent<Button>().onClick.RemoveAllListeners();
            upgradeCards[i].GetComponent<Button>().onClick
                .AddListener(() =>
                {
                    selectedUpgrades[index].ApplyUpgrade(player.gameObject, Rarity.Common);
                    onUpgradeChosen?.Invoke();
                });
        }
    }

    private void OnEnable()
    {
        player = FindObjectOfType<Player>();
        availabeUpgrades.Clear();
        GenerateUpgradeChoices();
        
        AudioManager.Instance.PlaySFX("Upgrade");

        if(borderImages != null)
        {
            for (int i = 0; i < borderImages.Count(); i++)
            {
                borderImages[i].SetActive(false);
            }
        }
        borderImages.Clear();
        availabeUpgrades.Clear();
        //ChooseUpgrades();
        //ListUpgrades();
    }
    
    
    /*
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
    */
    /*public void UpgradeChosen(Upgrade chosenUpgrade)
    {
        Debug.Log(chosenUpgrade.Title);
        switch (chosenUpgrade.UpgradeType)
        {
            case UpgradeType.Health:
                player.maxHealth += (int)chosenUpgrade.Increase;
                player.health = player.maxHealth;
                player.SetHealthBar();
                break;
            case UpgradeType.FireRate:
                weapon.fireRate +=  chosenUpgrade.Increase * 0.01f * weapon.fireRate;
                break;
            case UpgradeType.Magazine:
                weapon.magSize += Mathf.RoundToInt(chosenUpgrade.Increase * 0.01f * weapon.magSize);
                break;
            case UpgradeType.ReloadSpeed:
                weapon.reloadSpeed -= chosenUpgrade.Increase * 0.01f * weapon.reloadSpeed;
                break;
            case UpgradeType.MovementSpeed:
                player.moveSpeed += chosenUpgrade.Increase * 0.01f * player.moveSpeed;
                break;
            case UpgradeType.Unique:
                if(chosenUpgrade.Title == "Electromagnetism")
                {
                    Debug.Log("Magnetic");
                    player.magnetic = true;
                }
                if (chosenUpgrade.Title == "LeaTech's Leaked Weapon Design")
                {
                    weapon.bulletDMG *= 2; weapon.isKnockbackEnabled = true;
                }
                if(chosenUpgrade.Title == "Dire's Vengeance")
                {
                    weapon.bulletDMG *= chosenUpgrade.Increase * 0.01f;
                    weapon.diresVengeance = true;
                }
                break;
        }
        this.gameObject.SetActive(false);
    }*/
    /*public Upgrade GetClassWithValue(Upgrade[] array, string targetValue)
    {
        foreach (Upgrade item in array)
        {
            if (item.Title == targetValue)
            {
                return item;
            }
        }
        return null;
    }*/
    public enum Rarity
    {
        Common,
        Rare,
        Epic,
        Legendary
    }
}
