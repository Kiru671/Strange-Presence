using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class Player : MonoBehaviour
{
    public static event Action setXP;
    public static event Action setHP;
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
        setHP?.Invoke();
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
    
    public void GainXP(int gainedXP)
    {
        XP += gainedXP;
        if (XP >= xpCap)
        {
            LevelUp();
        }
        setHP?.Invoke();
    }

    void LevelUp()
    {
        XP = 0;
        xpCap += 10;
        onLevelUp?.Invoke();
    }
}
