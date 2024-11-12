using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.VFX;

public class BulletPool : MonoBehaviour
{
    public ObjectPool<Bullet> objectPool;

    [SerializeField] private bool collectionCheck;
    [SerializeField] private int defaultCap = 4;
    [SerializeField] private int maxSize = 20;

    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private Weapon chosenWeapon;
    [SerializeField] private GameObject Player;
    private Transform bulletSpawnPoint;
    private Bullet bullet;
    private VisualEffect bulletVFX;

    private void Awake()
    {
        objectPool = new ObjectPool<Bullet>(CreateGround, OnPull, OnRelease, OnDestroyGround, collectionCheck, defaultCap, maxSize);
        
        if(chosenWeapon == null)
            chosenWeapon = Player.GetComponentInChildren<Weapon>();
        else
            Debug.LogError("No weapon attached to player.");

        //Always set BulletSpawn as first child!
        bulletSpawnPoint = chosenWeapon.transform.GetChild(0);
        bullet = bulletPrefab.GetComponent<Bullet>();
        bulletVFX = bulletPrefab.GetComponentInChildren<VisualEffect>();
    }

    private Bullet CreateGround()
    {
        Bullet bulletInstance = Instantiate(bullet, Vector3.zero, Quaternion.identity);
        bulletInstance.gameObject.SetActive(false);
        return bulletInstance;
    }

    void OnPull(Bullet bulletInstance)
    {
        bulletInstance.gameObject.SetActive(true);
        bulletInstance.gameObject.transform.position = bulletSpawnPoint.position;
        bulletInstance.gameObject.transform.localRotation = Quaternion.Euler(0,Player.transform.localEulerAngles.y,0);
        //bulletVFX.SetFloat("BulletRotation", Player.transform.eulerAngles.y);
    }

    void OnRelease(Bullet bulletInstance)
    {
        bulletInstance.gameObject.SetActive(false);
    }

    void OnDestroyGround(Bullet bulletInstance)
    {

    }
}
