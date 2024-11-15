using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private ShowWaveDecal decal;

    private bool waveCleared;
    public int currentWave = 0;
    private int enemyCount;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyCount = 15; //Placeholder. Change with enemy spawner remaining enemycount.
        Invoke("StartGame", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (waveCleared)
        {
            NextWave();
        }
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextWave();
        }
    }
#endif
    private void NextWave()
    {
        Debug.Log($"Current Wave: {currentWave}");
        currentWave++;
        waveCleared = false;
        decal.enabled = true;
    }
    private void StartGame()
    {
        decal.enabled = true;
    }
}
