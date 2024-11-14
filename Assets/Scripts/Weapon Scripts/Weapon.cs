using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Weapon : MonoBehaviour
{
    private PlayerInputManager inputManager;
    protected BulletPool bulletPool; 
    protected VisualEffect muzzleFlash;
    [SerializeField] protected Cooldown cooldown;
    // Start is called before the first frame update
    void Awake()
    {
        muzzleFlash = GetComponentInChildren<VisualEffect>();
        bulletPool = GameObject.Find("BulletPool").GetComponent<BulletPool>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public virtual void Fire()
    {

    }
}
