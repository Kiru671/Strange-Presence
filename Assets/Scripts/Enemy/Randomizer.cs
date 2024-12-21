using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using System;


public class Randomizer
{
    [SerializeField] private GameObject player;

    public Vector3 GetSpawnPos(float spawnRange)
    {
        Vector3 playerPos = GameObject.Find("Player").GetComponent<Transform>().position;
        Vector2 randomV2 = UnityEngine.Random.insideUnitCircle;
        Vector2 spawnPos = randomV2.normalized * spawnRange;
        Vector3 returnPos = new Vector3(spawnPos.x + playerPos.x, playerPos.y + 10, spawnPos.y + playerPos.z);
        return returnPos;   
    }

    public List<string> RandomizeList(List<string> listToShuffle)
    {
        System.Random rand = new System.Random();
        for (int i = listToShuffle.Count - 1; i > 0; i--)
        {
            var k = rand.Next(i + 1);
            (listToShuffle[k], listToShuffle[i]) = (listToShuffle[i], listToShuffle[k]);
        }
        return listToShuffle;
    }
}
