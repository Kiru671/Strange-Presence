using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected EnemyDataObject enemyData;
    [SerializeField] protected XPOrb xpOrb;
    [SerializeField] protected Player player;
    protected Randomizer randomizer;
    protected int maxHealth;
    [SerializeField] protected int health;
    [SerializeField] protected float attackRange;
    [SerializeField] protected Animator anim;
    [SerializeField] protected float lookSpeed;
    [SerializeField] protected Slider healthSlider;
    [SerializeField] protected NavMeshAgent agent;

    void Start()
    {
        randomizer = new Randomizer();
        player = GameObject.Find("Player").GetComponent<Player>();     
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = Quaternion.Slerp(transform.rotation, player.transform.rotation, lookSpeed * Time.deltaTime);
    }
    public virtual void GetHit(int damage)
    {

    }


}
