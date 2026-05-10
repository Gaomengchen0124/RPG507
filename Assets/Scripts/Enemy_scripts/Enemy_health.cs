using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_health : MonoBehaviour
{
    public int max_health;
    public int cur_health;

    public GameObject healthbarCanvas;
    public Image hpImg;
    public Image hpEffectImg;
    public float buffTime = 0.5f;

    private Coroutine updateCoroutine;

    void Start()
    {
        cur_health = max_health;
        UpdateHealthBar();
    }

    public void Changehealth(int amount)
    {
        cur_health += amount;

        if (cur_health <= 0)
        {
            gameObject.SetActive(false);
            healthbarCanvas.SetActive(false);
        }

        cur_health = Mathf.Clamp(cur_health, 0, max_health);
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        hpImg.fillAmount = (float)cur_health / max_health;

        if (updateCoroutine != null)
            StopCoroutine(updateCoroutine);

        updateCoroutine = StartCoroutine(UpdateHpEffect());
    }

    IEnumerator UpdateHpEffect()
    {
        float elapsedTime = 0f;
        float startValue = hpEffectImg.fillAmount;
        float targetValue = hpImg.fillAmount;

        while (elapsedTime < buffTime)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / buffTime;
            hpEffectImg.fillAmount = Mathf.Lerp(startValue, targetValue, t);
            yield return null;
        }

        hpEffectImg.fillAmount = targetValue;
    }
}