using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave", menuName = "Waves/New Wave Data")]
public class WaveDataObject : ScriptableObject
{
    public WaveType waveType;
    private GameObject bossPrefab;
    public int orbedCount;
    public int vorgCount;
    public int enhancedVorglCount;
    public int totalEnemyCount;
}
public enum WaveType
{
    Normal,
    Boss,
    Special,
}

