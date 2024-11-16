using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected EnemyDataObject enemyData;
    [SerializeField] protected XPOrb xpOrb;
    [SerializeField] protected Player player;
    protected Randomizer randomizer;
    protected int MaxHealth;
    [SerializeField] protected int health;

    void Start()
    {
        randomizer = new Randomizer();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetHit(int damage)
    { 
        Debug.Log("Hit!");
        health -= damage;
    }

 
}
