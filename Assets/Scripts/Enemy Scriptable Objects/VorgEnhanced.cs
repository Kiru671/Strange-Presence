using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VorgEnhanced : Enemy
{
    private float damage;
    private float attackCooldown;
    private int enemyXP;

    void Start()
    {
        health = enemyData.maxHealth;
        damage = enemyData.damage;
        attackCooldown = enemyData.attackCooldown;
        enemyXP = enemyData.enemyXP;
    }

    void Update()
    {

    }

    void Attack()
    {

    }
    
    void GetHit(float damage)
    {

    }

    void Die(float damage)
    {

    }
}
