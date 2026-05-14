using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class player_health : MonoBehaviour
{

    public Image hpImg;
    public Image hpEffectImg;
    public float buffTime = 0.5f;

    private Coroutine updateCoroutine;

    public TMP_Text hpText;

    void Start()
    {
        StatsManager.Instance.cur_health = StatsManager.Instance.max_health;
        UpdateHealthBar();
        UpdateHealthText();
    }

    public void ChangeHealth(int amount)
    {
        StatsManager.Instance.cur_health += amount;

        if (StatsManager.Instance.cur_health <= 0)
        {
            gameObject.SetActive(false);
        }

        StatsManager.Instance.cur_health = Mathf.Clamp(StatsManager.Instance.cur_health, 0, StatsManager.Instance.max_health);
        UpdateHealthBar();
        UpdateHealthText();
    }

    void UpdateHealthBar()
    {
        hpImg.fillAmount = (float)StatsManager.Instance.cur_health / StatsManager.Instance.max_health;

        if (updateCoroutine != null)
            StopCoroutine(updateCoroutine);

        updateCoroutine = StartCoroutine(UpdateHpEffect());
    }

    void UpdateHealthText()
    {
        hpText.text = "Hp: " + StatsManager.Instance.cur_health + '/' + StatsManager.Instance.max_health;
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