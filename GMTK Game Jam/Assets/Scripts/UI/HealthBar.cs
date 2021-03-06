using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject unit;
    [SerializeField] private Image greenBar;
    [SerializeField] private GameObject greenBarSprite;
    [SerializeField] private Image feedbackLife;
    [SerializeField] private float maxFeedbackOpacity;

    public void Update()
    {
        IAttackable observedUnit = unit.GetComponent<IAttackable>();
        if(greenBar != null)
        {
            greenBar.fillAmount = Mathf.Clamp01((float)observedUnit.Hp / (float)observedUnit.MaxHp);
            Color feedbackLifeColor = feedbackLife.color;
            feedbackLifeColor.a = (0.5f - greenBar.fillAmount) * 1.5f;
            feedbackLife.color = feedbackLifeColor;
        }
        else if (greenBarSprite !=null)
        {
            greenBarSprite.transform.localScale = new Vector3(
                Mathf.Clamp01((float)observedUnit.Hp / (float)observedUnit.MaxHp) * .3f, 0.5f, 1);
            if (observedUnit.Hp <= 0) gameObject.SetActive(false);
        }
    }
}
