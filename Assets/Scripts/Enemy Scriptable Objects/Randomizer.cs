using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Randomizer
{
    [SerializeField] private GameObject player;


    public Vector3 GetSpawnPos(float spawnRange)
    {
        Vector3 playerPos = GameObject.Find("Player").GetComponent<Transform>().position;
        Vector2 randomV2 = Random.insideUnitCircle;
        Vector2 spawnPos = randomV2.normalized * spawnRange;
        Vector3 returnPos = new Vector3(spawnPos.x + playerPos.x,0, spawnPos.y + playerPos.z);
        return returnPos;   
    }

    public bool SetEnemyVariant()
    {
        return false;
    }
}
