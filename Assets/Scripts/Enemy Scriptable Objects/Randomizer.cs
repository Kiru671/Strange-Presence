using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer
{
    [SerializeField] private GameObject player;

    public Vector3 GetSpawnPos()
    {
        return new Vector3(0,0,0);
    }
    public bool SetEnemyVariant()
    {
        return false;
    }
}
