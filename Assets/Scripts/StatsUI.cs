using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsSystem : MonoBehaviour
{
    public GameObject[] StatsSlops;
    public CanvasGroup canvasGroup;
    private bool isStatsopened = false;
    private void Start()
    {
        UpdateAllStats();
    }
    
    private void Update()
    {
        if (Input.GetButtonDown("ToggleStats"))
        {
            if ( isStatsopened)
            {
                UpdateAllStats();
                isStatsopened = false;
                canvasGroup.alpha = 0;
                Time.timeScale = 1;
            } else
            {
                UpdateAllStats();
                isStatsopened = true;
                canvasGroup.alpha = 1;
                Time.timeScale = 0;
            }
        }
    }
    private void UpdateDamage()
    {
        StatsSlops[0].GetComponentInChildren<TMP_Text>().text = "Damage:" + StatsManager.Instance.damage;
    }

    private void UpdateSpeed()
    {
        StatsSlops[1].GetComponentInChildren<TMP_Text>().text = "Speed:" + StatsManager.Instance.speed;
    }

    private void UpdateRange()
    {
        StatsSlops[2].GetComponentInChildren<TMP_Text>().text = "Range:" + StatsManager.Instance.weaponRange;
    }

    private void UpdateAllStats()
    {
        UpdateDamage();
        UpdateSpeed();
        UpdateRange();
    }
}
