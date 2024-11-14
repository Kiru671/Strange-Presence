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
    private float magSize;
    private float currentAmmo;

    private bool IsReloading => currentAmmo == 0;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnEnable()
    {
        weaponWeight = weaponData.weaponWeight;
        bulletDMG = weaponData.bulletDMG;
        fireRate = weaponData.fireRate;
        reloadSpeed = weaponData.reloadSpeed;
        magSize = weaponData.magSize;
        currentAmmo = magSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Fire();
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
        currentAmmo = magSize;
    }

}
