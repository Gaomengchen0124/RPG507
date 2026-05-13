using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillSlot : MonoBehaviour
{
    public SkillSO skillSO;
    public Image skillIcon;
    public int curLevel = 0;
    public bool isUnlocked = false;
    public TMP_Text skillLevelText;
    public Button skillButton;

    public static event Action<SkillSlot> OnAvaliablePointSpent;
    public static event Action<SkillSlot> OnLevelMax;

    public List<SkillSlot> prerequisuteSkillSolts;
    private void OnValidate() {
        if ( skillIcon != null && skillLevelText != null)
        {
            UpdateUI();
        }
    }
    private void UpdateUI()
    {
        skillIcon.sprite = skillSO.skillIcon;
        if (isUnlocked)
        {
            skillButton.interactable = true;
            skillLevelText.text = curLevel.ToString() + '/' + skillSO.maxLevel.ToString();
            skillIcon.color = Color.white;
        }else
        {
            skillButton.interactable = false;
            skillLevelText.text = "???";
            skillIcon.color = Color.grey;
        }
    }

    public void TryUpgradeSkill()
    {
        if ( isUnlocked && curLevel < skillSO.maxLevel)
        {
            curLevel++;
            OnAvaliablePointSpent?.Invoke( this );
            UpdateUI();
        }
        if ( curLevel == skillSO.maxLevel)
        {
            OnLevelMax?.Invoke( this);
        }
    }
    public void Unlock()
    {
        isUnlocked = true;
        UpdateUI();
    }

    public bool CanUnlock()
    {
        foreach( SkillSlot preslot in prerequisuteSkillSolts)
        {
            if (!preslot.isUnlocked || preslot.curLevel < preslot.skillSO.maxLevel)
            {
                return false;
            }
        }
        return true;
    }
}
