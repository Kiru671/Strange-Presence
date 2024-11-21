using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    protected Randomizer randomizer;
    protected GameManager gameManager;
    protected AudioManager audioManager;
    
    [SerializeField] protected EnemyDataObject enemyData;
    [SerializeField] protected XPOrb xpOrb;
    [SerializeField] protected Player player;
    [SerializeField] protected int maxHealth;
    [SerializeField] protected int health;
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

    void Start()
    {
        randomizer = new Randomizer();
        player = GameObject.Find("Player").GetComponent<Player>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        Pools = GameObject.Find("EnemyPool");
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = Quaternion.Slerp(transform.rotation, player.transform.rotation, lookSpeed * Time.deltaTime);
    }

    public void KnockedBack()
    {

    }

    public virtual void GetHit(int damage)
    {
        if (deathStarted)
            return;
        health -= damage;
        healthSlider.value = (float)health / maxHealth;
        anim.SetTrigger("Hit");
        if (health <= 0)
        {
            Die();
        }
    }
    public virtual void Die()
    {
        healthSlider.gameObject.SetActive(false);
        gameManager.RemoveEnemy();
        gameObject.GetComponent<BoxCollider>().enabled = false;
        xpOrb = Instantiate(xpOrb, transform.position + Vector3.up * 1.5f, Quaternion.identity);
        xpOrb.containedXP = enemyXP;
        anim.SetTrigger("Death");
        if (!deathStarted)
            StartCoroutine("DieAfter");
    }


}
