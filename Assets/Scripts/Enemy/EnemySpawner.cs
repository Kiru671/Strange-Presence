using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{   
    [SerializeField] private WaveDataObject[] waves;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private EnemyPool enemyPoolSkeletons;
    [SerializeField] private EnemyPoolOrbed enemyPoolOrbeds;
    [SerializeField] private EnemyPoolVorg enemyPoolVorgs;



    [SerializeField] private Enemy initialEnemy;

    private Randomizer randomizer;
    private Enemy enemy;
    public int enemiesRemaining;

    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;

    [SerializeField] private float spawnRadius;

    public List<string> enemiesToSpawn = new List<string>();

    private int vorgCount;
    private int enhancedVorgCount;
    private int orbedCount;
    private int skeletonCount;
    private int totalEnemyCount;

    public int MaxWave => waves.Length - 1;


    private float timeUntilSpawn;

    void Awake()
    {
        Debug.Log(MaxWave);
        randomizer = new Randomizer();
        SetTimeUntilSpawn();
        ChangeWave();
    }

    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;

        if (enemiesRemaining <= 0)
        {
            ChangeWave();
        }
        if (timeUntilSpawn <= 0 && gameManager.currentWave > 0 && enemiesToSpawn.Count > 0)
        {
            SpawnAd();
            SetTimeUntilSpawn();
        }
    }

    private void SpawnAd()
    {
        Vector3 spawnPos = randomizer.GetSpawnPos(spawnRadius);
        bool navmeshHit = NavMesh.SamplePosition(spawnPos, out NavMeshHit hit, 100, NavMesh.AllAreas);
        Debug.Log(navmeshHit);
        while (!navmeshHit)
        {
            navmeshHit = NavMesh.SamplePosition(randomizer.GetSpawnPos(spawnRadius), out hit, 100, NavMesh.AllAreas);
            Debug.Log("Retried");
        }
        Enemy enemyInstance = null;

        if (enemiesToSpawn[enemiesToSpawn.Count - 1] == "Skeleton")
        {
            enemyInstance = enemyPoolSkeletons.objectPool.Get();
            //Debug.Log(enemyInstance.GetComponent<NavMeshAgent>().Warp(hit.position));
            enemiesToSpawn.Remove("Skeleton");
        }
        else if (enemiesToSpawn[enemiesToSpawn.Count - 1] == "Orbed")
        {
            enemyInstance = enemyPoolOrbeds.objectPool.Get();
            enemiesToSpawn.Remove("Orbed");
        }
        else if (enemiesToSpawn[enemiesToSpawn.Count - 1] == "Vorg")
        {
            enemyInstance = enemyPoolVorgs.objectPool.Get();
            enemiesToSpawn.Remove("Vorg");
        }
        else
            Debug.Log("All enemies in this wave have spawned.");
        
        if (enemyInstance != null)
        {
            enemyInstance.GetComponent<NavMeshAgent>().enabled = true; 
            enemyInstance.transform.position = hit.position;
        }
    }

    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }
    public void ChangeWave()
    {
        skeletonCount = waves[gameManager.currentWave].skeletonCount;
        orbedCount = waves[gameManager.currentWave].orbedCount;
        vorgCount = waves[gameManager.currentWave].vorgCount;
        enhancedVorgCount = waves[gameManager.currentWave].enhancedVorgCount;
        enemiesRemaining = waves[gameManager.currentWave].totalEnemyCount;
        gameManager.enemyCount = enemiesRemaining;

        enemiesToSpawn.Clear();


        for (int i = 0; i < skeletonCount; i++)
        {
            enemiesToSpawn.Add("Skeleton");
        }
        for (int i = 0; i < orbedCount; i++)
        {
            enemiesToSpawn.Add("Orbed");
        }
        for (int i = 0; i < vorgCount; i++)
        {
            enemiesToSpawn.Add("Vorg");
        }
        for (int i = 0; i < enhancedVorgCount; i++)
        {
            enemiesToSpawn.Add("EnhancedVorg");
        }
        randomizer.RandomizeList(enemiesToSpawn);
    }

}
