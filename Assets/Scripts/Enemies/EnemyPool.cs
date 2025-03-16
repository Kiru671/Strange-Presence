using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;

public class EnemyPool : MonoBehaviour
{
    public ObjectPool<GameObject> objectPool;

    [SerializeField] private bool collectionCheck;
    [SerializeField] private int defaultCap = 4;
    [SerializeField] private int maxSize = 20;

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject Player;

    private void Awake()
    {
        objectPool = new ObjectPool<GameObject>(CreateSkeletons, OnPull, OnRelease, OnDestroyEnemy, collectionCheck, defaultCap, maxSize);
    }

    private GameObject CreateSkeletons()
    {
        GameObject enemyInstance = Instantiate(enemyPrefab);
        enemyInstance.gameObject.SetActive(false);
        return enemyInstance;
    }

    void OnPull(GameObject enemyInstance)
    {
        // Enable the GameObject first
        enemyInstance.gameObject.SetActive(true);
    }

    void OnRelease(GameObject enemyInstance)
    {
        var agent = enemyInstance.GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.enabled = false;
        }
        enemyInstance.gameObject.SetActive(false);
    }

    void OnDestroyEnemy(GameObject enemyInstance)
    {
        Destroy(enemyInstance.gameObject);
    }
}