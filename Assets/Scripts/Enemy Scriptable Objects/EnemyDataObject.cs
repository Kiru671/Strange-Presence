using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemies/New Enemy Data")]
public class EnemyDataObject : ScriptableObject
{
    public int maxHealth;
    public int damage;
    public float attackCooldown;
    public int enemyXP;
}
