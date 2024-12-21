using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FirstSkeleton : Enemy
{
    private int damage;
    private float attackCooldown;
    private float nextAttack;

    private bool TargetInRange => Vector3.Distance(transform.position, player.transform.position) < attackRange;
    private bool attacking;


    void Awake()
    {

    }

    private void OnEnable()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        anim = GetComponentInChildren<Animator>();
        gameObject.GetComponent<BoxCollider>().enabled = true;
        deathStarted = false;
        anim.SetBool("isDying", false);
        health = enemyData.maxHealth;
        maxHealth = enemyData.maxHealth;
        damage = enemyData.damage;
        attackCooldown = enemyData.attackCooldown;
        attackRange = enemyData.attackRange;
        enemyXP = enemyData.enemyXP;
        healthSlider.gameObject.SetActive(true);

    }

    public override void KnockedBack()
    {
        throw new NotImplementedException();
    }

    private void OnDisable()
    {
        StopCoroutine("CheckGround");
    }

    void Update()
    {
        if (TargetInRange & !attacking)
        {
            Attack(damage);
        }
    }

    public override void Die()
    {
        throw new NotImplementedException();
    }

    public override void Attack(int damage)
    {
        if (deathStarted)
            return;

        if (Time.time > nextAttack)
        {
            nextAttack = Time.time + attackCooldown;
            anim.SetTrigger("Attack");
        }
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
