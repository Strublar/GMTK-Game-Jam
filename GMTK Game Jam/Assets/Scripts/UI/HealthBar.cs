using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject unit;
    [SerializeField] private Image greenBar;
    [SerializeField] private GameObject greenBarSprite;
    public void Update()
    {
        IAttackable observedUnit = unit.GetComponent<IAttackable>();
        if(greenBar != null)
        {
            greenBar.fillAmount = Mathf.Clamp01((float)observedUnit.Hp / (float)observedUnit.MaxHp);
        }
        else if (greenBarSprite !=null)
        {
            greenBarSprite.transform.localScale = new Vector3(
                Mathf.Clamp01((float)observedUnit.Hp / (float)observedUnit.MaxHp) * .3f, 0.5f, 1);
        }
    }
}
