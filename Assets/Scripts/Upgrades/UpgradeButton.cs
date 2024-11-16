using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private Upgrades upgrades;

    public void Upgrade()
    {
        string chosenUpgrade = gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        upgrades.UpgradeChosen(chosenUpgrade);
        Debug.Log("Upgrade clicked");
        Time.timeScale = 1;
    }
}
