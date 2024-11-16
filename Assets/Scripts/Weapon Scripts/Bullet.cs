using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float bulletspeed;
    private float bulletDamage; 
    private BulletPool pool;
    private float bulletDespawnTimer = 1f;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        pool = FindObjectOfType<BulletPool>();
        player = GameObject.Find("Player").GetComponent<Player>();
        StartCoroutine("DestroyAfterTime", bulletDespawnTimer);
    }
    private void OnEnable()
    {
        StartCoroutine("DestroyAfterTime", bulletDespawnTimer);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += transform.forward * bulletspeed * Time.deltaTime;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
            other.gameObject.GetComponent<Enemy>().GetHit(player.damage);
            pool.objectPool.Release(this);
    }

    private IEnumerator DestroyAfterTime(float t)
    {
        yield return new WaitForSeconds(t);
        pool.objectPool.Release(this);
    }
}
