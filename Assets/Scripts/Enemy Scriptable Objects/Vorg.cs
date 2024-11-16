using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vorg : Enemy
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

    void Attack(float damage)
    {

    }

    private void OnDestroy()
    {
        xpOrb = Instantiate(xpOrb, transform.position, Quaternion.identity);
        xpOrb.containedXP = enemyXP;
    }


}
