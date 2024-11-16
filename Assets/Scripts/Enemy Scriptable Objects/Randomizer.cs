using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Randomizer
{
    [SerializeField] private GameObject player;

    public Vector3 GetSpawnPos()
    {
        Vector2 playerPos = GameObject.Find("Player").GetComponent<Transform>().position;
        Vector2 spawnPoint = Random.insideUnitCircle;
        Vector2 spawnPos = spawnPoint - playerPos.normalized;
        Vector3 returnPos = new Vector3(spawnPos.x, -8.75f, spawnPos.y);
        return returnPos;   
    }
    public bool SetEnemyVariant()
    {
        return false;
    }
}
