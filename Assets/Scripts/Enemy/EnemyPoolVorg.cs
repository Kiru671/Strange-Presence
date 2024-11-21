using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.VFX;

public class EnemyPoolVorg : MonoBehaviour
{
    public ObjectPool<Enemy> objectPool;

    [SerializeField] private bool collectionCheck;
    [SerializeField] private int defaultCap = 4;
    [SerializeField] private int maxSize = 20;

    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private GameObject Player;
    private Enemy enemy;

    private void Awake()
    {
        objectPool = new ObjectPool<Enemy>(CreateGround, OnPull, OnRelease, OnDestroyEnemy, collectionCheck, defaultCap, maxSize);

        enemy = enemyPrefab.GetComponent<Enemy>();
    }

    private Enemy CreateGround()
    {
        Enemy enemyInstance = Instantiate(enemy, Vector3.zero, Quaternion.identity);
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
