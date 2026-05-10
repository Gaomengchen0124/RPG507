using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_combat : MonoBehaviour
{
    public Animator anim;
    public Transform attackpoint;
    public LayerMask EnemyLayer;
    public float weaponRange;
    public int damage;
    public float coolDown;
    private float timer;

    public float KnockBackForce = 50;
    public float stunTime = 0.1f;
    
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
            timer = coolDown;
        }
    }
    
    public void DealDamage()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll( attackpoint.position, weaponRange, EnemyLayer);
        if ( enemy.Length > 0)
        {
            enemy[0].GetComponent<Enemy_health>().Changehealth(-damage);
            enemy[0].GetComponent<Enemy_KnockBack>().KnockBack(transform, StatsManager.Instance.KnockBackForce, StatsManager.Instance.stunTime);
        }
    }

        private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere( attackpoint.position, weaponRange);

    }
    public void FinishAttacking()
    {
        anim.SetBool("isAttacking", false);
    }
}
