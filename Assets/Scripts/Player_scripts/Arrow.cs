using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Rigidbody2D rd;
    public Vector2 direction = Vector2.right;
    public float speed;
    public float LifeSpan;
    public LayerMask enemyLayer;
    public int damage = 2;
    public int force = 2;
    public int stuntime = 1;
    // Start is called before the first frame update
    void Start()
    {
        rd.velocity = speed * direction;
        RotateArrow();
        Destroy(gameObject, LifeSpan);
    }
    private void RotateArrow()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler( new Vector3(0,0,angle));
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (( enemyLayer.value & (1 << other.gameObject.layer)) > 0 )
        {
            other.gameObject.GetComponent<Enemy_health>().Changehealth(-damage);
            other.gameObject.GetComponent<Enemy_KnockBack>().KnockBack( transform, force, stuntime);
        }
    }
}
