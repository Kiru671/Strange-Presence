using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pistol : Weapon
{
    public WeaponDataObject weaponData; 
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
        if (Input.GetKey(KeyCode.Mouse0)){
            Fire();
        }
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
        if (cooldown.IsCoolingDown || IsReloading)
            return;
        if (!diresVengeance)
        {
            Debug.Log("Fire");
            Bullet bulletInstance = bulletPool.objectPool.Get();
            bulletInstance.knockBack = isKnockbackEnabled;
            bulletInstance.transform.position = bulletSpawns[0].position;
            bulletInstance.gameObject.transform.localRotation = Quaternion.Euler(0, player.transform.localEulerAngles.y, 0);
            muzzleFlash.Play();
        }
        else
        {
            for (int i = 0; i <= 2; i++)
            {
                Bullet bulletInstance = bulletPool.objectPool.Get();
                bulletInstance.knockBack = isKnockbackEnabled;
                bulletInstance.transform.position = bulletSpawns[i].position;
                if(i == 0)               
                    bulletInstance.gameObject.transform.localRotation = Quaternion.Euler(0, player.transform.localEulerAngles.y, 0);
                if(i == 1)
                    bulletInstance.gameObject.transform.localRotation = Quaternion.Euler(0, player.transform.localEulerAngles.y + 30f, 0);
                if (i == 2)
                    bulletInstance.gameObject.transform.localRotation = Quaternion.Euler(0, player.transform.localEulerAngles.y - 30f, 0);
                muzzleFlash.Play();
            }
            
            
        }
        cooldown.cooldownTime = 60 / fireRate;
        cooldown.StartCooldown();
        currentAmmo--;
    }

    private IEnumerator Reload(float t)
    {
        yield return new WaitForSeconds(t);
        Debug.Log("Reloaded!");
        reloadStarted = false;
        currentAmmo = magSize;
    }
}
