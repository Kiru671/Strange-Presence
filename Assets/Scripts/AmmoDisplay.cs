using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoDisplay : MonoBehaviour
{
    private Weapon weapon;
    [SerializeField] private TextMeshProUGUI ammoText;

    void Start()
    {
        weapon = GameObject.Find("Player").GetComponent<Transform>().GetChild(0).GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = string.Format("{0}/{1}", weapon.currentAmmo, weapon.magSize);
    }
}
