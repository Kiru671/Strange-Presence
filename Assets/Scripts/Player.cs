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
    [SerializeField] private int xpCap;
    public bool magnetic = false;

    [SerializeField] private Upgrades upgrades;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider xpBar;

    void Start()
    {
        health = maxHealth;
        healthBar.value = 1;
        xpBar.value = 0;
    }

    void Update()
    {
        
    }

    public void GetHit(int damage)
    {
        health -= damage;
        healthBar.value = (float)health / maxHealth;
    }

    void Die()
    {

    }
    
    public void GainXP(int gainedXP)
    {
        xpBar.value = (float)XP / xpCap;
        XP += gainedXP;
        if(XP >= xpCap)
        {
            LevelUp();
            Debug.Log("Leveled up!");
        }
    }

    void LevelUp()
    {
        upgrades.gameObject.SetActive(true);
        xpCap += 20;
        StartCoroutine("StopTime");
    }

    private IEnumerator StopTime()
    {
        while (upgrades.gameObject.activeInHierarchy) 
        {
            Debug.Log("Timestop running");

            if (Time.timeScale >= 0.015f)
                Time.timeScale -= 0.0125f;
            else
                Time.timeScale = 0;       

            yield return new WaitForSeconds(0.002f);

        }
        StopCoroutine(StopTime());
    }
}
