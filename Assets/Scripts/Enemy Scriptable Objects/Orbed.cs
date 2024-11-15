using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbed : Enemy
{
    private int health;
    private float damage;
    private float attackCooldown;
    private bool willThrow;
    
    void Start()
    {
        health = enemyData.maxHealth;
        damage = enemyData.damage;
        attackCooldown = enemyData.attackCooldown;
    }

    private void OnEnable()
    {
        willThrow = randomizer.SetEnemyVariant();
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

    void GetHit()
    {

    }

    void Die()
    {

    }
}
