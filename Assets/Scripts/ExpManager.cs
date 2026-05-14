using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ExpManager : MonoBehaviour
{
    public int level;
    public int curExp;
    public int expToNextLevel = 10;
    public float expGrowthMultiplier = 1.5F;
    public Slider expSlider;
    public TMP_Text expText;

    public static event Action<int> OnLevelUp;

    private void Start()
    {
        UpdateUI();
    }
    private void GainExp( int amount)
    {
        curExp += amount;
        if ( curExp >= expToNextLevel)
        {
            LevelUp();
        }
        UpdateUI();
    }

    private void LevelUp()
    {
        level ++;
        curExp -= expToNextLevel;
        expToNextLevel *= Mathf.RoundToInt(expGrowthMultiplier);
        OnLevelUp?.Invoke(3);//这里可以加逻辑，先都是3吧
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //Debug.Log("回车键被按下了！");
            GainExp(2);
        }
    }
    
    private void UpdateUI()
    {
        expSlider.maxValue = expToNextLevel;
        expSlider.value = curExp;
        expText.text = "Level " + level;
    }

    private void OnEnable()
    {
        Enemy_health.OnMonsterDefeated += GainExp;
    }
    private void OnDisable() {
        Enemy_health.OnMonsterDefeated -= GainExp;
    }
}
