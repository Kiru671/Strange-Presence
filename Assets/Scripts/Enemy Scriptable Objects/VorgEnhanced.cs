using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VorgEnhanced : Enemy
{
    private int health;
    private float damage;
    private float attackCooldown;

    void Start()
    {
        health = enemyData.maxHealth;
        damage = enemyData.damage;
        attackCooldown = enemyData.attackCooldown;
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