using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class Skeleton : Enemy
{
    private void OnEnable()
    {
        health = enemyData.maxHealth;
        maxHealth = enemyData.maxHealth;
        damage = enemyData.damage;
        attackCooldown = enemyData.attackCooldown;
        attackRange = enemyData.attackRange;
        enemyXP = enemyData.enemyXP;
        healthSlider.gameObject.SetActive(true);
        healthSlider.value = (float)health / maxHealth;
        firstHit = false;
        gameObject.GetComponent<BoxCollider>().enabled = true;
        agent.enabled = true;
        agent.isStopped = false;
    }

    public override void KnockedBack()
    {

    }
    
    public override void PlayAnimWalkSound()
    {
        AudioManager.Instance.PlaySFX("SkeletonWalk");
    }
}
