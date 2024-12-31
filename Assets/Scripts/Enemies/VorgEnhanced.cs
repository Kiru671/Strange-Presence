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

    public override void KnockedBack()
    {
        throw new System.NotImplementedException();
    }

    public override void Die()
    {
        throw new System.NotImplementedException();
    }

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public override void PlayAnimWalkSound()
    {
        AudioManager.Instance.PlaySFX("EnhancedVorgWalk");
    }


    void GetHit(float damage)
    {

    }

    void Die(float damage)
    {

    }
}
