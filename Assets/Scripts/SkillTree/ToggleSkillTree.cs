using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSkillTree : MonoBehaviour
{
    public bool isTreeOpened;
    public CanvasGroup canvasGroup;


    private void Update() {
        if ( Input.GetButtonDown("ToggleSkillTree"))
        {
            if (isTreeOpened)
            {
                isTreeOpened = false;
                canvasGroup.alpha = 0;
                Time.timeScale = 1;
                canvasGroup.blocksRaycasts = false;
            } else
            {
                isTreeOpened = true;
                canvasGroup.alpha = 1;
                Time.timeScale = 0;
                canvasGroup.blocksRaycasts = true;
            }
        }
    }
}
