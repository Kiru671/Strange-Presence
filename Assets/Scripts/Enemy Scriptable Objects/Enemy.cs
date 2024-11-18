using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    protected Randomizer randomizer;
    protected GameManager gameManager;
    
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

    public float knockbackForce = 10f;
    public float knockbackDuration = 0.5f;

    private bool isKnockedBack = false;
    private float knockbackTime = 0f;

    void Start()
    {
        randomizer = new Randomizer();
        player = GameObject.Find("Player").GetComponent<Player>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = Quaternion.Slerp(transform.rotation, player.transform.rotation, lookSpeed * Time.deltaTime);
    }
    public virtual void GetHit(int damage)
    {

    }
    public void KnockedBack()
    {

    }


}
