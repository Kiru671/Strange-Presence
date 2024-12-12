using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class Player : MonoBehaviour
{
    public static event Action onXpChanged;
    public static event Action onHpChanged;
    public static event Action onPlayerDeath;
    public static event Action onLevelUp;
    
    public int maxHealth = 100;
    public int health = 100;
    public float moveSpeed = 4f;
    public int damage;
    public int XP;
    public int xpCap;
    public bool magnetic;
    public bool isDead;
    
    [SerializeField] protected CinemachineShake virtualCam;
    
    void Start()
    {
        health = maxHealth;
        XP = 0;
        xpCap = 5;
        virtualCam = GameObject.Find("VirtualCamera").GetComponent<CinemachineShake>();
    }

    public void GetHit(int damage)
    {
        health -= damage;
        HealthUpdate();
        virtualCam.Shake(damage * 0.25f, 0.2f);
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        onPlayerDeath?.Invoke();
        AudioManager.Instance.musicSource.Pause();
    }
    
    public void GainXp(int gainedXp)
    {
        XP += gainedXp;
        if (XP >= xpCap)
        {
            LevelUp();
        }
        onXpChanged?.Invoke();
    }

    void LevelUp()
    {
        XP = 0;
        xpCap += 10;
        onLevelUp?.Invoke();
    }

    public void HealthUpdate()
    {
        onHpChanged?.Invoke();
    }
}
