using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private UpgradeManager upgrades;

    public void Upgrade()
    {
        /*
         Time.timeScale = 1;
        upgrades.UpgradeChosen(upgrades.GetClassWithValue(upgrades.upgrades, gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text));
        AudioManager.Instance.PlaySFX("UpgradeChosen");
        Debug.Log("Upgrade clicked"); 
        */
    }
}
