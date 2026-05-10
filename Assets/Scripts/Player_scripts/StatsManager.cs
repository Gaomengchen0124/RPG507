using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public static StatsManager Instance;
    [Header("Combat Stats")]
    public int damage;
    public float weaponRange;
    public float coolDown;
    public float KnockBackForce;
    public float stunTime;
    [Header("Movement Stats")]
    public int speed;
    [Header("Health Stats")]
    public int max_health;
    public int cur_health;

    private void Awake() {
        if ( Instance == null )
        {
            Instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }
}
