using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    private Rigidbody2D rd;
    private Transform player;
    public float speed;
    private EnemyState enemystate;
    public Animator anim;
    public float attackrange;
    public float attackCooldown = 2;
    private float attackCooldownTimer;
    public Transform checkpoint;
    public float playerDetecRange;
    public LayerMask playerLayer;

    void Start() 
    {
        rd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ChangeState( EnemyState.Idle);
    }

    void FixedUpdate()
    {
        if ( enemystate != EnemyState.KnockBack)
        {
            CheckforPlayer();
            if ( attackCooldownTimer > 0)
            {
                attackCooldownTimer -= Time.deltaTime;
            }
            if (enemystate == EnemyState.Chasing)
            {
                Chase();
            } else if ( enemystate == EnemyState.Attacking)
            {
                rd.velocity = Vector2.zero;
            }
        }
        
    }

    void Chase()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rd.velocity = direction * speed;
        if (Vector2.Distance( transform.position, player.transform.position) <= attackrange && attackCooldownTimer <= 0)
        {
            attackCooldownTimer = attackCooldown;
            ChangeState(EnemyState.Attacking);
        } else if (transform.localScale.x > 0 && direction.x < 0 || transform.localScale.x < 0 && direction.x > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                
        } 
    }

    private void CheckforPlayer() 
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll( checkpoint.position, playerDetecRange, playerLayer);
        if ( hits.Length > 0)
        {
            player = hits[0].transform;
            if (Vector2.Distance( transform.position, player.position) <= attackrange && attackCooldownTimer <= 0)
            {
                attackCooldownTimer = attackCooldown;
                ChangeState(EnemyState.Attacking);
            }
            else if (Vector2.Distance( transform.position, player.position) > attackrange && enemystate != EnemyState.Attacking)
            {
                ChangeState(EnemyState.Chasing);
            }
        }
        else
        {
            ChangeState(EnemyState.Idle);
            rd.velocity = Vector2.zero;
        }
    }

    public void ChangeState( EnemyState newState)
    {
        if ( enemystate == EnemyState.Idle)
        {
            anim.SetBool("IsIdle", false);
        } else if ( enemystate == EnemyState.Chasing)
        {
            anim.SetBool("IsChasing", false);
        } else if ( enemystate == EnemyState.Attacking)
        {
            anim.SetBool("IsAttacking", false);
        }

        enemystate = newState;

        if ( enemystate == EnemyState.Idle)
        {
            anim.SetBool("IsIdle", true);
        } else if ( enemystate == EnemyState.Chasing)
        {
            anim.SetBool("IsChasing", true);
        } else if ( enemystate == EnemyState.Attacking)
        {
            anim.SetBool("IsAttacking", true);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere( checkpoint.position, playerDetecRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere( transform.position, attackrange);
    }

}

public enum EnemyState
{        
    Idle,        
    Chasing,
    Attacking,
    KnockBack
}