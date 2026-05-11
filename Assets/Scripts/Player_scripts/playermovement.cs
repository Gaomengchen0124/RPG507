using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public Rigidbody2D rd;
    public Animator anim;
    private bool isKnockBack = false;
    public SpriteRenderer spriteRenderer;
    public Player_combat player_combat;
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetButtonDown("Slash"))
        {
            player_combat.Attack();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if ( isKnockBack == false )
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if ( !spriteRenderer.flipX && horizontal < 0 || spriteRenderer.flipX && horizontal > 0)
            {
                Flip();
            }

            anim.SetFloat("horizontal", Mathf.Abs(horizontal));
            anim.SetFloat("vertical", Mathf.Abs(vertical));
            rd.velocity = new Vector2( horizontal, vertical)*StatsManager.Instance.speed;
        }
    }

    public void KnockBack( Transform enemy, float force, float stunTime)
    {
        isKnockBack = true;
        Vector2 direction = (transform.position - enemy.position).normalized;
        rd.velocity = direction * force;
        StartCoroutine(KnockBackCounter(stunTime));
    }

    IEnumerator KnockBackCounter( float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
        rd.velocity = Vector2.zero;
        isKnockBack = false;

    }

    void Flip()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}
