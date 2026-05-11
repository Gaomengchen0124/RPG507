using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_combat : MonoBehaviour
{
    public Animator anim;
    public Transform attackpoint;
    public LayerMask EnemyLayer;
    private float timer;

    private void Update()
    {
        if ( timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }
    public void Attack()
    {
        if ( timer <= 0)
        {
            anim.SetBool("isAttacking", true);
            timer = StatsManager.Instance.coolDown;
        }
    }
    
    public void DealDamage()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll( attackpoint.position, StatsManager.Instance.weaponRange, EnemyLayer);
        if ( enemy.Length > 0)
        {
            enemy[0].GetComponent<Enemy_health>().Changehealth(-StatsManager.Instance.damage);
            enemy[0].GetComponent<Enemy_KnockBack>().KnockBack(transform, StatsManager.Instance.KnockBackForce, StatsManager.Instance.stunTime);
        }
    }

        private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere( attackpoint.position, StatsManager.Instance.weaponRange);

    }
    public void FinishAttacking()
    {
        anim.SetBool("isAttacking", false);
    }
}
