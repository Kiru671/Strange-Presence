using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;
using UnityEngine.VFX;

public class EnemyPool : MonoBehaviour
{
    public ObjectPool<Enemy> objectPool;

    [SerializeField] private bool collectionCheck;
    [SerializeField] private int defaultCap = 4;
    [SerializeField] private int maxSize = 20;

    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private GameObject Player;
    private NavMeshAgent agent;
    private Enemy enemy;

    private void Awake()
    {
        objectPool = new ObjectPool<Enemy>(CreateSkeletons, OnPull, OnRelease, OnDestroyEnemy, collectionCheck, defaultCap, maxSize);
        enemy = enemyPrefab.GetComponent<Enemy>();
    }

    private Enemy CreateSkeletons()
    {
        Enemy enemyInstance = Instantiate(enemy, new Vector3(-16,-8, -107), Quaternion.identity);
        enemyInstance.GetComponent<NavMeshAgent>().enabled = false;
        enemyInstance.gameObject.SetActive(false);
        return enemyInstance;
    }

    void OnPull(Enemy enemyInstance)
    {
        enemyInstance.gameObject.SetActive(true);
    }

    void OnRelease(Enemy enemyInstance)
    {
        enemyInstance.gameObject.SetActive(false);
    }

    void OnDestroyEnemy(Enemy enemyInstance)
    {

    }
}
