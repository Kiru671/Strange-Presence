using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Weapon : MonoBehaviour
{
    private BulletPool bulletPool;
    private PlayerInputManager inputManager;
    private VisualEffect muzzleFlash;
    // Start is called before the first frame update
    void Start()
    {
        muzzleFlash = GetComponentInChildren<VisualEffect>();
        bulletPool = GameObject.Find("BulletPool").GetComponent<BulletPool>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Fire();
    }
    void Fire()
    {
        Debug.Log("Fire");
        bulletPool.objectPool.Get();
        muzzleFlash.Play();
    }
}
