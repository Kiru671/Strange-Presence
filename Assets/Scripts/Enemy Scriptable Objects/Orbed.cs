using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Orbed : Enemy
{
    private int damage;
    private float attackCooldown;
    private bool willThrow;
    private int enemyXP;
    private Rigidbody rb;
    private bool deathStarted;

    private bool TargetInRange => Vector3.Distance(transform.position, player.transform.position) < attackRange;
    private bool attacking;


    void Awake()
    {
        health = enemyData.maxHealth;
        damage = enemyData.damage;
        attackCooldown = enemyData.attackCooldown;
        enemyXP = enemyData.enemyXP;
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        //willThrow = randomizer.SetEnemyVariant();
        gameObject.GetComponent<BoxCollider>().enabled = true;
        deathStarted = false;
        anim.SetBool("isDying", false);
        health = enemyData.maxHealth;
        maxHealth = enemyData.maxHealth;
        damage = enemyData.damage;
        attackCooldown = enemyData.attackCooldown;
        attackRange = enemyData.attackRange;
        healthSlider.enabled = true;
        
    }
    private void OnDisable()
    {
        StopCoroutine("CheckGround");
    }

    void Update()
    {
        if (deathStarted)
        {
            anim.SetFloat("Speed", 0);
            return;
        }
        anim.SetFloat("Speed", agent.velocity.magnitude);


        if (!agent.isOnNavMesh)
        {
            StartCoroutine("CheckGround");
        }
        else
        {
            agent.SetDestination(player.transform.position);
        }
        if(TargetInRange &! attacking)
        {
            Attack(damage);
        }
    }

    void Attack(int damage)
    {
        if (deathStarted)
            return;
        anim.SetTrigger("RightAttack");

        /*if (!attacking)
        {
            attacking = true;
            StartCoroutine("DamageAfter");
        }*/
    }

    public override void GetHit(int damage)
    {
        if (deathStarted)
            return;
        //healthSlider.enabled = true;
        health -= damage;
        healthSlider.value = (float)health / maxHealth;
        anim.SetTrigger("Hit");
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        xpOrb = Instantiate(xpOrb, transform.position + Vector3.up * 1f, Quaternion.identity);
        xpOrb.containedXP = enemyXP;
        anim.SetTrigger("Death");
        if(!deathStarted)
            StartCoroutine("DieAfter");
    }

    private IEnumerator CheckGround()
    {
        yield return new WaitForSeconds(1f);
        if (!agent.isOnNavMesh)
        {
            Vector3 newSpawnPos = randomizer.GetSpawnPos(30f);
            Vector3 adjustedPos = new Vector3(newSpawnPos.x, -9.81f, newSpawnPos.z); ;
            gameObject.transform.position = adjustedPos;
            agent.Warp(adjustedPos);
            
        }
        else
            Debug.Log("SAFE!");
        StopCoroutine("CheckGround");
    }
    private IEnumerator DamageAfter()
    {
        yield return new WaitForSeconds(0.2f);
        if (TargetInRange)
        {
            player.GetHit(damage);
        }
        yield return new WaitForSeconds(attackCooldown);
        attacking = false;
    }

    private IEnumerator DieAfter()
    {
        agent.speed = 0;
        deathStarted = true;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    public void DamageIfInRange()
    {
        if (TargetInRange)
        {
            player.GetHit(damage);
        }
    }
}
