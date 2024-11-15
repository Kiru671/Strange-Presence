using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Weapons/New Weapon Data")]
public class WeaponDataObject : ScriptableObject
{
    public WeaponType weaponType;
    public float weaponWeight;
    public float bulletDMG;
    public float fireRate;
    public float reloadSpeed;
    public int magSize;
}
public enum WeaponType
{
    Pistol,
    Shotgun,
    AssaultRifle,
    BoltAction
}

