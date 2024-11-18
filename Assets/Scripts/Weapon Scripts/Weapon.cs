using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.VFX;

public class Weapon : MonoBehaviour
{
    protected PlayerInputManager inputManager;
    protected BulletPool bulletPool;
    protected VisualEffect muzzleFlash;
    [SerializeField] protected VisualEffect direFlash;
    [SerializeField] protected VisualEffect direFlash1;
    public float weaponWeight;
    public float bulletDMG;
    public float fireRate;
    public float reloadSpeed; //Lower is better
    public bool isKnockbackEnabled;
    public bool diresVengeance;
    public int magSize;
    [SerializeField] protected Cooldown cooldown;

    protected Transform[] bulletSpawnPoint;
    protected List<Transform> bulletSpawns = new List<Transform>();
    protected Player player;
    public bool IsReloading => currentAmmo <= 0;
    public int currentAmmo;
    // Start is called before the first frame update
    void Awake()
    {
        //Always set BulletSpawn as first child!
        for (int i = 0; i <= 2; i++)
        {
            bulletSpawns.Add(transform.GetChild(i).GetComponent<Transform>());
        }
        bulletSpawnPoint = bulletSpawns.ToArray();
        muzzleFlash = GetComponentInChildren<VisualEffect>();
        bulletPool = GameObject.Find("BulletPool").GetComponent<BulletPool>();
        inputManager = GameObject.Find("Player").GetComponent<PlayerInputManager>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public virtual void Fire()
    {

    }
    public void OnConnectedToServer()
    {
        
    }
}
