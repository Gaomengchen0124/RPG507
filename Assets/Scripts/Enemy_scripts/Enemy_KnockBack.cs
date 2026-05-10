using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_KnockBack : MonoBehaviour
{
    private Rigidbody2D rd;
    private Enemy_Movement enemy_Movement;

    void Start() {
        rd = GetComponent<Rigidbody2D>();
        enemy_Movement = GetComponent<Enemy_Movement>();
    }
    public void KnockBack( Transform playertransform, float force, float stunTime)
    {
        enemy_Movement.ChangeState( EnemyState.KnockBack);
        Vector2 direction = (transform.position - playertransform.position).normalized;
        rd.velocity = direction * force;
        StartCoroutine(KnockBackTimer(stunTime));
    }

    IEnumerator KnockBackTimer( float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
        rd.velocity = Vector2.zero;
        enemy_Movement.ChangeState( EnemyState.Idle);
    }
}
