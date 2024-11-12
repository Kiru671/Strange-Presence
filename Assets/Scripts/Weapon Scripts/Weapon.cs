using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private BulletPool bulletPool;
    private PlayerInputManager inputManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Fire();
    }
    void Fire()
    {
        bulletPool.objectPool.Get();
    }
}
