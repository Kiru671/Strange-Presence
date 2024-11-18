using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int health = 100;
    public float moveSpeed = 4f;
    public int damage;
    public int XP;
    public int xpCap;
    public bool magnetic;

    private AudioManager audioManager;

    [SerializeField] private Upgrades upgrades;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider xpBar;

    

    [SerializeField] protected CinemachineShake virtualCam;

    void Start()
    {
        health = maxHealth;
        healthBar.value = 1;
        xpBar.value = 0.01f;
        XP = 0;
        xpCap = 5;
        virtualCam = GameObject.Find("VirtualCamera").GetComponent<CinemachineShake>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    void Update()
    {
        
    }

    public void GetHit(int damage)
    {
        health -= damage;
        healthBar.value = (float)health / maxHealth;
        virtualCam.Shake(damage * 0.25f, 0.2f);
    }

    void Die()
    {

    }
    
    public void GainXP(int gainedXP)
    {
        Debug.Log("Gained XP!");
        XP += gainedXP;
        xpBar.value = (float)XP / (float)xpCap;
        if (XP >= xpCap)
        {
            Debug.Log("Checkxp");
            XP = 0;
            LevelUp();
            Debug.Log("Leveled up!");
        }
    }

    void LevelUp()
    {
        upgrades.gameObject.SetActive(true);
        xpCap += 10;
        StartCoroutine("StopTime");
    }

    private IEnumerator StopTime()
    {
        while (upgrades.gameObject.activeInHierarchy) 
        {
            if (Time.timeScale >= 0.015f)
                Time.timeScale -= 0.0125f;
            else
                Time.timeScale = 0;       

            yield return new WaitForSeconds(0.00175f);

        }
        StopCoroutine(StopTime());
    }
    public void SetHealthBar()
    {
        healthBar.value = (float)health / maxHealth;
    }
    public void SetXPBar()
    {
        xpBar.value = (float)XP / xpCap;
    }
}
