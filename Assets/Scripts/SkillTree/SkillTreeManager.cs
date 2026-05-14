using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillTreeManager : MonoBehaviour
{
    public TMP_Text pointsText;
    public float availablePoint;
    public SkillSlot[] skillSlots;
    private void OnEnable() {
        SkillSlot.OnAvaliablePointSpent += HandlePointSpent;
        SkillSlot.OnLevelMax += HandleLevelMax;
        ExpManager.OnLevelUp += UpdateAvailablePoints;
    }
    private void OnDisable() {
        SkillSlot.OnAvaliablePointSpent -= HandlePointSpent;
        SkillSlot.OnLevelMax += HandleLevelMax;
        ExpManager.OnLevelUp -= UpdateAvailablePoints;
    }
    private void Start() {//这一步是给每个按钮绑定监听和升级方法
        foreach( SkillSlot slot in skillSlots)
        {
            slot.skillButton.onClick.AddListener(()=> CheckAvailablePoints(slot));
        }
        UpdateAvailablePoints(0);
    }

    public void CheckAvailablePoints(SkillSlot slot)
    {
        if ( availablePoint > 0)
        {
            slot.TryUpgradeSkill();
        }
    }

    public void UpdateAvailablePoints( int amount)
    {
        availablePoint += amount;
        pointsText.text = "Points: " + availablePoint;
    }
    private void HandlePointSpent(SkillSlot slot)
    {
        if ( availablePoint > 0)
        {
            UpdateAvailablePoints(-1);
        }
    }
    private void HandleLevelMax(SkillSlot slot)
    {
        foreach( SkillSlot skillslot in skillSlots)
        {
            if ( !skillslot.isUnlocked && skillslot.CanUnlock())
            skillslot.Unlock();
        }
    }

}
