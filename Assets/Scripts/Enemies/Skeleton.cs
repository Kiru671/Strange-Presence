using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class Skeleton : Enemy
{
    private int damage;
    private float attackCooldown;
    private float nextAttack;

    private bool TargetInRange => Vector3.Distance(transform.position, player.transform.position) < attackRange;
    private bool attacking;
    

    private void OnEnable()
    {
        
        player = GameObject.Find("Player").GetComponent<Player>();
        anim = GetComponent<Animator>();
        //gameObject.GetComponent<BoxCollider>().enabled = true;
        deathStarted = false;
        anim.SetBool("isDying", false);
        health = enemyData.maxHealth;
        maxHealth = enemyData.maxHealth;
        damage = enemyData.damage;
        attackCooldown = enemyData.attackCooldown;
        attackRange = enemyData.attackRange;
        enemyXP = enemyData.enemyXP;
        healthSlider.gameObject.SetActive(true);
        healthSlider.value = (float)health / maxHealth;
    }
    

    void Update()
    {
        if (deathStarted)
        {
            anim.SetFloat("Speed", 0);
            return;
        }
        anim.SetFloat("Speed", agent.velocity.magnitude);
        
        if(TargetInRange &! attacking)
        {
            Attack(damage);
        }
    }

    void Attack(int damage)
    {
        if (deathStarted)
            return;    

        if (Time.time > nextAttack) 
        {
            nextAttack = Time.time + attackCooldown;
            anim.SetTrigger("Attack");
            AudioManager.Instance.PlaySFX("SkeletonAttack");
        }       
    }

    private IEnumerator DieAfter()
    {
        agent.speed = 0;
        deathStarted = true;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        //Pools.gameObject.GetComponent<EnemyPool>().objectPool.Release(this);
    }

    public void DamageIfInRange()
    {
        if (TargetInRange)
        {
            player.GetHit(damage);
        }
    }
}
