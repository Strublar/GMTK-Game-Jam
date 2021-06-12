using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity, IAttackable
{

    [SerializeField] private float aggroRange;
    [SerializeField] private int hp;

    [SerializeField] private float immunityFrame;
    private float lastDamageFrame;

    public int Hp { get => hp; set => hp = value; }
    public float ImmunityFrame { get => immunityFrame; set => immunityFrame = value; }
    public float AggroRange { get => aggroRange; set => aggroRange = value; }
    public float LastDamageFrame { get => lastDamageFrame; set => lastDamageFrame = value; }

    public void OnAttacked(OnAttackedArgs args)
    {
        throw new System.NotImplementedException();
    }


    

    



}
