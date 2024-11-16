using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Health = 100;
    public float moveSpeed = 4f;
    public int damage;
    public int XP;
    [SerializeField] private int xpCap;
    public bool magnetic = false;

    [SerializeField] private Upgrades upgrades;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GetHit(int damage)
    {

    }

    void Die()
    {

    }
    public void GainXP(int gainedXP)
    {
        XP += gainedXP;
        if(XP >= xpCap)
        {
            LevelUp();
        }
    }
    void LevelUp()
    {
        upgrades.enabled = true;
        Time.timeScale = 0;
    }

}
