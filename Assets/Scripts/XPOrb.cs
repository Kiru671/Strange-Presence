using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPOrb : MonoBehaviour
{
    private Player player;
    public int containedXP;
    [SerializeField] private float magnetismSpeed;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.magnetic)
        {
            transform.position += (magnetismSpeed * Time.deltaTime) * (player.transform.position - transform.position);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player.GainXP(containedXP);
        }
    }
}
