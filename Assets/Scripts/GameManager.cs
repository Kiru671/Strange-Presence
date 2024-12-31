using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using Upgrades;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private ShowWaveDecal decal;
    [SerializeField] private Player player;
    [SerializeField] private GameObject stopScreen;
    [SerializeField] private GameObject settingsScreen;
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject completeScreen;
    public Timer timer;

    private Weapon chosenWeapon;

    private bool waveCleared;
    private bool gameWon;
    public bool gameStopped;
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

    public void CompleteScreen()
    {
        completeScreen.SetActive(true);
        gameWon = true;
    }

    public void NextWave()
    {
        AudioManager.Instance.PlaySFX("New wave");
        currentWave++;
        if (currentWave == 1)
            timer.enabled = true;
        if (currentWave == enemySpawner.MaxWave)
        {
            CompleteScreen();
        }
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
    public void StopGame()
    {
        Time.timeScale = 0f;
        gameStopped = true;
        stopScreen.SetActive(true);
    }
    public void ResumeGame()
    {
        UpgradeManager upgradeManager = GameObject.Find("Upgrade")?.GetComponent<UpgradeManager>();
        if (upgradeManager != null && !upgradeManager.enabled)
        {
            stopScreen.SetActive(false);
            gameStopped = false;
            return;
        }
        stopScreen.SetActive(false);
        gameStopped = false;
        Time.timeScale = 1f;
        
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene("Falan");
        Time.timeScale = 1f;
        AudioManager.Instance.musicSource.Stop();
        AudioManager.Instance.musicSource.Play();
    }
    public void EnableSettingsPanel()
    {
        gameStopped = true;
        if (deathScreen.activeInHierarchy)
        {
            deathScreen.SetActive(false);
            
        }
        stopScreen.SetActive(false);
        settingsScreen.SetActive(true);
        completeScreen.SetActive(false);
    }
    public void BackFromSettings()
    {
        settingsScreen.SetActive(false);
        
        if (player.isDead)
        {
            deathScreen.SetActive(true);
            return;
        }
        else if (gameWon)
        {
            completeScreen.SetActive(true);
        }
        if(gameStopped)
            ResumeGame();
        else
            stopScreen.SetActive(true);      
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
