using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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

    private List<Enemy> enemiesToSpawn = new List<Enemy>();

    private int vorgCount;
    private int enhancedVorgCount;
    private int orbedCount;
    private int totalEnemyCount;

    private float timeUntilSpawn;

    void Awake()
    {
        randomizer = new Randomizer();
        SetTimeUntilSpawn();
    }

    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;

        if (timeUntilSpawn <= 0)
        {
            SpawnAd();
            SetTimeUntilSpawn();
        }
        if(enemiesRemaining <= 0)
        {
            ChangeWave();
        }
    }

    private void SpawnAd()
    {
        if (gameManager.currentWave == 0)
        {
            Instantiate(initialEnemy);
            return;
        }
        //new List<Enemy>().Add();
        Vector3 spawnPos = randomizer.GetSpawnPos(spawnRadius);

        Enemy enemyInstance = enemyPoolSkeletons.objectPool.Get();
        enemyInstance.transform.position = new Vector3(spawnPos.x, 0, spawnPos.z);
    }

    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }
    private void ChangeWave()
    {
        enemiesRemaining = waves[gameManager.currentWave].totalEnemyCount;
        for (int i = 0; i >= totalEnemyCount; i++)
        {
            if (waves[gameManager.currentWave].vorgCount > 0) 
            {
                enemiesToSpawn.Add(enemyPoolVorgs.objectPool.Get());
            }

            
        }
    }
    public void RemoveEnemy()
    {
        enemiesRemaining--;
    }
}
