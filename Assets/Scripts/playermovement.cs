using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody2D rd;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if ( transform.localScale.x > 0 && horizontal < 0 || transform.localScale.x < 0 && horizontal > 0)
        {
            Flip();
        }

        anim.SetFloat("horizontal", Mathf.Abs(horizontal));
        anim.SetFloat("vertical", Mathf.Abs(vertical));
        rd.velocity = new Vector2( horizontal, vertical)*speed;
    }

    void Flip()
    {
        transform.localScale = new Vector3( transform.localScale.x * -1,transform.localScale.y, transform.localScale.z );
    }
}
