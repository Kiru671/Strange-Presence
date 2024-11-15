using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponAnimController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private Weapon chosenWeapon;
    // Start is called before the first frame update
    void Start()
    {
        chosenWeapon = GetComponent<Weapon>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator == null)
        {
            Debug.Log("No animator attached to controller.");
        }
        else if(chosenWeapon.IsReloading)
        {
            Debug.Log("ReloadAnim");
            animator.SetTrigger("Reload");
        }
    }
}
