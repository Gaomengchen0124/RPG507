using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public TMP_Text hpText;

    private void Awake() {
        if ( Instance == null )
        {
            Instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateMaxHealth(int amount)
    {
        max_health += amount;
        cur_health = max_health;
        hpText.text = "hp: "+ cur_health + '/' + max_health; 
    }
}
