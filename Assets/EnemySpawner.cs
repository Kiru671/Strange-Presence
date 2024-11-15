using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{   
    [SerializeField] private WaveDataObject[] waves;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private EnemyPool enemyPool;
    private Randomizer randomizer;
    private Enemy enemy;
    public int enemiesRemaining;

    void Start()
    {

    }

    void Update()
    {
        enemiesRemaining = waves[gameManager.currentWave].EnemySpawnCount;
        switch (waves[gameManager.currentWave].waveType)
        {
            case WaveType.Normal:
                
                break;
            case WaveType.Boss:

                break;
            case WaveType.Special:
                break;
        }
    }
    private void SpawnAd()
    {
        enemy = enemyPool.objectPool.Get();
        enemy.transform.position = randomizer.GetSpawnPos();
    }
}
