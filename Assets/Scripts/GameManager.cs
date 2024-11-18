using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private ShowWaveDecal decal;
    [SerializeField] private Player player;
    private Weapon chosenWeapon;

    private bool waveCleared;
    public int currentWave = 0;
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartGame", 1f);
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextWave();

        }
#endif
    }

    public void NextWave()
    {
        currentWave++;
        enemySpawner.ChangeWave();
        Debug.Log($"Current Wave: {currentWave}");
        decal.enabled = true;
    }

    private void StartGame()
    {
        decal.enabled = true;
    }

    public void RemoveEnemy()
    {
        enemySpawner.enemiesRemaining--;
        if (enemySpawner.enemiesRemaining <= 0)
        {
            NextWave();         
        }
    }
}
