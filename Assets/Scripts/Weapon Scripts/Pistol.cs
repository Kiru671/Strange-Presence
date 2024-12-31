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
        if (Input.GetKey(KeyCode.Mouse0) &! inputManager.gamepadMoving)
        {
            Fire();
        }
        if (inputManager.rotation.magnitude > 0 &! IsReloading)
            Fire();

        else if(IsReloading &! reloadStarted)
        {
            Debug.Log("RELOADING!");
            reloadStarted = true;
            AudioManager.Instance.PlaySFX("Reload");
            StartCoroutine("Reload", reloadSpeed);
        }
    }

    public override void Fire()
    {
        if (cooldown.IsCoolingDown || IsReloading)
            return;
        FireDireBullets(bulletCount, bulletSpread);
        AudioManager.Instance.PlaySFX("RifleFire");
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

    public void FireDireBullets(int bulletCount, float spreadAngle)
    {
        int tempBulletCount = bulletCount;
        float angleStep = spreadAngle / ((tempBulletCount <= 1 ? 2 : tempBulletCount) - 1);
        float startAngle = player.transform.localEulerAngles.y - (spreadAngle / 2);

        for (int i = 0; i < bulletCount; i++)
        {
            // Get a new bullet from the pool for each iteration
            Bullet bulletInstance = bulletPool.objectPool.Get();
            bulletInstance.knockBack = isKnockbackEnabled;

            // Set position and rotation for the bullet
            bulletInstance.transform.position = bulletSpawns[Mathf.Min(i, bulletSpawns.Count - 1)].position;
            bulletInstance.gameObject.transform.localRotation = Quaternion.Euler(0, startAngle + (i * angleStep), 0);
        }

        muzzleFlash.Play();
    }

}
