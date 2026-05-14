using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private void OnEnable() {
        SkillSlot.OnAvaliablePointSpent += HandleAvailablePointSpent;
    }
    private void OnDisable() {
        SkillSlot.OnAvaliablePointSpent -= HandleAvailablePointSpent;
    }
    private void HandleAvailablePointSpent( SkillSlot slot)
    {
        string skillName = slot.skillSO.skillName;
        //通过创建一个类似技能库来避免一堆if,或者可以暂时使用switchcase
        switch(skillName){
            case("Max Heart Boost"):
                StatsManager.Instance.UpdateMaxHealth(1);
                break;
            default:
                Debug.LogWarning("Unknow skill: " + skillName);
                break;
        }
    }
}
