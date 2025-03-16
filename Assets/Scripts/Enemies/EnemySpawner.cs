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
    [SerializeField] private EnemyPool enemyPoolOrbeds;
    [SerializeField] private EnemyPool enemyPoolVorgs;
    private Player player;

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
        randomizer = new Randomizer();
        player = FindObjectOfType<Player>();
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
        // Get a valid NavMesh position
        NavMeshHit spawnPos = GetValidSpawnPosition();

        // Spawn the appropriate enemy type
        if (enemiesToSpawn.Count > 0)
        {
            string enemyType = enemiesToSpawn[^1];
            switch (enemyType)
            {
                case "Skeleton":
                    SpawnEnemy(enemyPoolSkeletons, spawnPos);
                    enemiesToSpawn.Remove("Skeleton");
                    break;
                case "Orbed":
                    SpawnEnemy(enemyPoolOrbeds, spawnPos);
                    enemiesToSpawn.Remove("Orbed");
                    break;
                case "Vorg":
                    SpawnEnemy(enemyPoolVorgs, spawnPos);
                    enemiesToSpawn.Remove("Vorg");
                    break;
                default:
                    Debug.LogWarning($"Unknown enemy type: {enemyType}");
                    break;
            }
        }
    }

    private NavMeshHit GetValidSpawnPosition()
    {
        NavMeshHit hit;
        
        Vector3 spawnPos = randomizer.GetSpawnPos(spawnRadius);
            
        if (NavMesh.SamplePosition(spawnPos, out hit, 100f, NavMesh.AllAreas))
        {
            return hit;
        }

        Debug.LogWarning("Could not find a valid spawn position");
        return hit;
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void SpawnEnemy(EnemyPool pool, NavMeshHit hit)
    {
        GameObject enemyInstance = pool.objectPool.Get();
        if (enemyInstance != null)
        {
            // First set the position
            enemyInstance.transform.position = hit.position;
            
            // Then enable the NavMeshAgent and set its position
            NavMeshAgent agent = enemyInstance.gameObject.GetComponent<NavMeshAgent>();
            agent.enabled = true;
            agent.SetDestination(transform.position);
            
            agent.Warp(hit.position);
        }
        else
        {
            Debug.Log("Enemy instance is null");
        }
    }

    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }

    public void ChangeWave()
    {
        skeletonCount = waves[gameManager.currentWave].skeletonCount;
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