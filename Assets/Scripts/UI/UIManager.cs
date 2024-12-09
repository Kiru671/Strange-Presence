using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private UpgradeManager upgradeManager;
    [SerializeField] private GameObject upgradeCanvas;
    [SerializeField] private GameObject deathPanel;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider xpBar;
    [SerializeField] private Timer timer;
    private Player player;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        player = GameObject.FindObjectOfType<Player>();
        SetBarsInitial();
        Player.setXP += SetXPBar;
        Player.setHP += SetHealthBar;
        Player.onPlayerDeath += EnableDeathPanel;
        Player.onLevelUp += EnableUpgrades;
        UpgradeManager.onUpgradeChosen += DisableUpgrades;
    }

    private void OnDisable()
    {
        Player.setXP -= SetXPBar;
        Player.setHP -= SetHealthBar;
        Player.onPlayerDeath -= EnableDeathPanel;
        Player.onLevelUp -= EnableUpgrades;
        UpgradeManager.onUpgradeChosen -= DisableUpgrades;
    }

    public void EnableUpgrades()
    {
        upgradeCanvas.SetActive(true);
    }
    
    public void DisableUpgrades()
    {
        upgradeCanvas.SetActive(false);
    }
    
    private void SetBarsInitial()
    {
        healthBar.value = 1;
        xpBar.value = 0.01f;
    }
    
    public void SetHealthBar()
    {
        healthBar.value = (float)player.health / player.maxHealth;
    }
    
    public void SetXPBar()
    {
        xpBar.value = (float)player.XP / player.xpCap;
    }
    
    private void EnableDeathPanel()
    {
        deathPanel.SetActive(true);
        timer.enabled = false;
    }
    
}
