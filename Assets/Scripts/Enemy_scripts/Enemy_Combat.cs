using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{
    public int damage = -1;
    public Transform attackpoint;
    public float weaponRange;
    public LayerMask playerLayer;
    public float knockbackForce = 5;
    public float stunTime;
    private void OnCollisionEnter2D(Collision2D other) {
        if( other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<player_health>().ChangeHealth(damage);
        }
    }

    public void Attack()
    {
        Debug.Log("Attack palyer Now!");
        Collider2D[] hits = Physics2D.OverlapCircleAll( attackpoint.position, weaponRange, playerLayer);
        if ( hits.Length > 0)
        {
            hits[0].GetComponent<player_health>().ChangeHealth(damage);
            hits[0].GetComponent<playermovement>().KnockBack(transform, knockbackForce,stunTime);
        }
    }
}
