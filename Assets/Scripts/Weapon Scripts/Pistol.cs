using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pistol : Weapon
{
    public WeaponDataObject weaponData;
    private float weaponWeight;
    private float bulletDMG;
    private float fireRate;
    private float reloadSpeed; //Lower is better
    private int magSize;
    private bool reloadStarted;

    

    private void OnEnable()
    {
        weaponWeight = weaponData.weaponWeight;
        bulletDMG = weaponData.bulletDMG;
        fireRate = weaponData.fireRate;
        reloadSpeed = weaponData.reloadSpeed;
        magSize = weaponData.magSize;
        currentAmmo = magSize;
    }

    void Update()
    {
#if UNITY_EDITOR

        if (Input.GetKey(KeyCode.Mouse0)){
            Fire();
        }
#endif
        if (inputManager.rotation.magnitude > 0 &! IsReloading)
            Fire();

        else if(IsReloading &! reloadStarted)
        {
            Debug.Log("RELOADING!");
            reloadStarted = true;
            StartCoroutine("Reload", reloadSpeed);
        }
    }

    public override void Fire()
    {
        if (cooldown.IsCoolingDown &! IsReloading)
            return;
        Debug.Log("Fire");
        bulletPool.objectPool.Get();
        muzzleFlash.Play();
        cooldown.cooldownTime = 60 / fireRate;
        cooldown.StartCooldown();
        currentAmmo--;
    }

    private IEnumerator Reload(float t)
    {
        yield return new WaitForSeconds(t);
        reloadStarted = false;
        currentAmmo = magSize;
    }
}
