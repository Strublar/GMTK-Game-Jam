using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{

    float LastDamageFrame { get; set; }
    float ImmunityFrame { get; set; }
    int Hp { get; set; }
    int MaxHp { get; set; }

    void OnAttacked(OnAttackedArgs args);

    
}

public struct OnAttackedArgs
{
    public GameObject attacker;
    public int damage;
}


