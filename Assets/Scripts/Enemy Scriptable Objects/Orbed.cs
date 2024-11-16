using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbed : Enemy
{
    private int damage;
    private float attackCooldown;
    private bool willThrow;
    private int enemyXP;
    
    void Start()
    {
        health = enemyData.maxHealth;
        damage = enemyData.damage;
        attackCooldown = enemyData.attackCooldown;
        enemyXP = enemyData.enemyXP;
    }

    private void OnEnable()
    {
        //willThrow = randomizer.SetEnemyVariant();
        health = enemyData.maxHealth;
        damage = enemyData.damage;
        attackCooldown = enemyData.attackCooldown;
    }

    void Update()
    {
        
    }

    void Attack(int damage)
    {

    }

    private void OnDestroy()
    {
        xpOrb = Instantiate(xpOrb, transform.position, Quaternion.identity);
        xpOrb.containedXP = enemyXP;
    }
}
