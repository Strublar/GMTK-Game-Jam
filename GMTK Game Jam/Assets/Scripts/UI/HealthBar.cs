using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Image greenBar;
    public void Update()
    {
        greenBar.fillAmount = (float)player.Hp / (float)player.MaxHp;
    }
}
