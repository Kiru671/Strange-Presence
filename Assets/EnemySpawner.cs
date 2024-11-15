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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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
