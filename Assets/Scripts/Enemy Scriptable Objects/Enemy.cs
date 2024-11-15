using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected EnemyDataObject enemyData;
    protected Randomizer randomizer;
    protected int MaxHealth;
    void Start()
    {
        randomizer = new Randomizer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
