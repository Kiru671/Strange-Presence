using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private Upgrades upgrades;

    public void Upgrade()
    {
        Time.timeScale = 1;
        string chosenUpgrade = gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        upgrades.UpgradeChosen(chosenUpgrade);
        Debug.Log("Upgrade clicked"); 
    }
}
