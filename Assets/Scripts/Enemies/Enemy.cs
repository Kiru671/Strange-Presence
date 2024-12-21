using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
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
    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] protected GameObject Pools;

    protected int enemyXP;

    public float knockbackForce = 10f;
    public float knockbackDuration = 0.5f;

    private bool isKnockedBack = false;
    private float knockbackTime = 0f;

    protected bool deathStarted;
    protected bool firstHit;
    
    protected float attackCooldown;
    protected float nextAttack;

    protected bool TargetInRange => Vector3.Distance(transform.position, player.transform.position) < attackRange;
    protected bool attacking;

    void Start()
    {
        randomizer = new Randomizer();
        player = GameObject.Find("Player").GetComponent<Player>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        Pools = GameObject.Find("EnemyPool");
        fadeOutOnDeath = healthSlider.gameObject.GetComponent<HealthBarFade>();
    }

    private void OnEnable()
    {
        firstHit = false;
    }

    public abstract void KnockedBack();

    public virtual void GetHit(int damage)
    {
        if (deathStarted)
            return;
        //Fade in the health bar when shot if enemy is shot for the first time.
        if (!firstHit)
        {
            StartCoroutine(fadeOutOnDeath.FadeIn());
            firstHit = true;
        }
        health -= damage;
        healthSlider.value = (float)health / maxHealth;
        anim.SetTrigger("Hit");
        if (health <= 0)
        {
            Die();
        }
    }

    public abstract void Die();
    public abstract void Attack(int damage);
}
