using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    protected Randomizer randomizer;
    protected GameManager gameManager;
    protected AudioManager audioManager;
    protected HealthBarFade fadeOutOnDeath;
    
    [SerializeField] protected EnemyDataObject enemyData;
    [SerializeField] protected XPOrb xpOrb;
    [SerializeField] protected Player player;
    [SerializeField] protected int maxHealth;
    [SerializeField] protected int health;
    [SerializeField] public int damage;
    [SerializeField] protected float attackRange;
    [SerializeField] protected Animator anim;
    [SerializeField] protected float lookSpeed;
    [SerializeField] protected Slider healthSlider;
    [SerializeField] public NavMeshAgent agent;
    [SerializeField] protected GameObject Pools;
    public event Action OnEnemyCooldownOver;
    public event Action OnEnemyHit;
    public event Action OnEnemyDeath;
    

    protected int enemyXP;

    public float knockbackForce = 10f;
    public float knockbackDuration = 0.5f;

    private bool isKnockedBack = false;
    private float knockbackTime = 0f;

    protected bool deathStarted;
    protected bool firstHit;
    
    protected float attackCooldown;
    protected float nextAttack = 0;

    public bool TargetInRange => Vector3.Distance(transform.position, player.transform.position) < attackRange;
    public bool AttackCooldown => Time.time > nextAttack;

    private void Awake()
    {
        randomizer = new Randomizer();
        fadeOutOnDeath = healthSlider.gameObject.GetComponent<HealthBarFade>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        Pools = GameObject.Find("EnemyPool");
        player = GameObject.Find("Player").GetComponent<Player>();
        anim = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        firstHit = false;
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }

    public abstract void KnockedBack();

    public virtual void GetHit(int damage)
    {
        OnHit();
        //Fade in the health bar when shot if enemy is shot for the first time.
        if (!firstHit)
        {
            StartCoroutine(fadeOutOnDeath.FadeIn());
            firstHit = true;
        }
        health -= damage;
        healthSlider.value = (float)health / maxHealth;
        
        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        StartCoroutine(fadeOutOnDeath.FadeOut());
        gameManager.RemoveEnemy();
        gameObject.GetComponent<BoxCollider>().enabled = false;
        xpOrb = Instantiate(xpOrb, transform.position + Vector3.up * 1.5f, Quaternion.identity);
        xpOrb.containedXP = enemyXP;
        OnDeath();
        if (!deathStarted)
            StartCoroutine("DieAfter");
    }
    private IEnumerator DieAfter()
    {
        agent.speed = 0;
        deathStarted = true;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        //Pools.gameObject.GetComponent<EnemyPool>().objectPool.Release(this);
    }

    public virtual void Attack()
    {
        nextAttack = Time.time + attackCooldown;
        AudioManager.Instance.PlaySFX("SkeletonAttack");
        //DamageIfInRange();
    }
    
    public void DamageIfInRange()
    {
        if (TargetInRange)
        {
            player.GetHit(damage);
        }
    }

    public virtual void OnCooldownOver()
    {
        OnEnemyCooldownOver?.Invoke();
    }

    public virtual void OnHit()
    {
        OnEnemyHit?.Invoke();
    }

    public virtual void OnDeath()
    {
        OnEnemyDeath?.Invoke();
    }

    public abstract void PlayAnimWalkSound();
    public void Gethit(int damage)
    {
        throw new NotImplementedException();
    }
}
