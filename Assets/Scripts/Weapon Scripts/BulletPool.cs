using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
    public ObjectPool<Bullet> objectPool;

    [SerializeField] private bool collectionCheck;
    [SerializeField] private int defaultCap = 4;
    [SerializeField] private int maxSize = 20;

    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Weapon chosenWeapon;
    [SerializeField] private GameObject Player;
    private Transform bulletSpawnPoint;

    private void Awake()
    {
        objectPool = new ObjectPool<Bullet>(CreateGround, OnPull, OnRelease, OnDestroyGround, collectionCheck, defaultCap, maxSize);
        chosenWeapon = Player.GetComponent<Weapon>();

        //Always set BulletSpawn as first child!
        bulletSpawnPoint = chosenWeapon.transform.GetChild(0);
    }

    private Bullet CreateGround()
    {
        Bullet bulletInstance = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity);
        bulletInstance.gameObject.SetActive(false);
        return bulletInstance;
    }

    void OnPull(Bullet bulletInstance)
    {
        bulletInstance.gameObject.SetActive(true);
        bulletInstance.gameObject.transform.position = bulletSpawnPoint.position;
    }

    void OnRelease(Bullet bulletInstance)
    {
        bulletInstance.gameObject.SetActive(false);
    }

    void OnDestroyGround(Bullet bulletInstance)
    {

    }
}
