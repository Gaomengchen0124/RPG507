using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Lauchpoint;
    public GameObject ArrowPerfabs;
    private Vector2 aimDirection = Vector2.right;
    public float shootCoolDown = .5f;
    public float shootTimer ;


    // Update is called once per frame
    void Update()
    {
        shootTimer -= Time.deltaTime;
        HandleAiming();
        if (Input.GetButtonDown("Shoot") && shootTimer <= 0)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        
        Arrow arrow = Instantiate(ArrowPerfabs, Lauchpoint.position, Quaternion.identity).GetComponent<Arrow>();
        arrow.direction = aimDirection;
        shootTimer = shootCoolDown;
    }

    private void HandleAiming()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if ( horizontal != 0 || vertical != 0)
        {
            aimDirection = new Vector2(horizontal, vertical);
        }

    }

}
