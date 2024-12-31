using System.Collections;
using UnityEngine;

namespace Enemies
{
    public class Vorg : Enemy
    {
        private int damage;
        private float attackCooldown;
        private float nextAttack;
        private int enemyXP;
        private bool deathStarted;
        private bool attacking;

        private bool TargetInRange => Vector3.Distance(transform.position, player.transform.position) < attackRange;


        private void OnEnable()
        {
            player = GameObject.Find("Player").GetComponent<Player>();
            gameObject.GetComponent<BoxCollider>().enabled = true;
            deathStarted = false;
            anim.SetBool("isDying", false);
            health = enemyData.maxHealth;
            maxHealth = enemyData.maxHealth;
            damage = enemyData.damage;
            attackCooldown = enemyData.attackCooldown;
            attackRange = enemyData.attackRange;
            enemyXP = enemyData.enemyXP;
            healthSlider.gameObject.SetActive(true);
        }

        public override void KnockedBack()
        {

        }

        void Update()
        {
            if (deathStarted)
            {
                anim.SetFloat("Speed", 0);
                return;
            }
            anim.SetFloat("Speed", agent.velocity.magnitude);


            if (!agent.isOnNavMesh)
            {
                StartCoroutine("CheckGround");
            }
            else
            {
                agent.SetDestination(player.transform.position);
            }
            if (TargetInRange & !attacking)
            {
                Attack();
            }
        }

        public override void GetHit(int damage)
        {
            if (deathStarted)
                return;
            health -= damage;
            healthSlider.value = (float)health / maxHealth;
            anim.SetTrigger("Hit");
            if (health <= 0)
            {
                Die();
            }
        }

        public override void Attack()
        {
            if (deathStarted || Time.time < nextAttack)
                return;
            nextAttack = Time.time + attackCooldown;
            anim.SetTrigger("Attack");
        }

        public override void Die()
        {
            healthSlider.gameObject.SetActive(false);
            gameManager.RemoveEnemy();
            xpOrb = Instantiate(xpOrb, transform.position + Vector3.up * 2.25f, Quaternion.identity);
            xpOrb.containedXP = enemyXP;
            StartCoroutine("DieAfter");
        }

        public void DamageIfInRange()
        {
            if (TargetInRange)
            {
                player.GetHit(damage);
            }
        }

        private IEnumerator DieAfter()
        {
            agent.speed = 0;
            deathStarted = true;
            yield return new WaitForSeconds(2f);
            Destroy(gameObject);
        }
        public override void PlayAnimWalkSound()
        {
            AudioManager.Instance.PlaySFX("VorgWalk");
        }
    }
}
