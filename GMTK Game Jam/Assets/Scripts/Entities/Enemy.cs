using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity, IAttackable
{

    [SerializeField] private float aggroRange;
    [SerializeField] private float hp;
    [SerializeField] private int maxHp;

    [SerializeField] private float immunityFrame;
    [SerializeField] private Rigidbody2D rb;
    private float lastDamageFrame;
    

    public float Hp { get => hp; set => hp = Mathf.Clamp(value, 0, maxHp); }
    public float ImmunityFrame { get => immunityFrame; set => immunityFrame = value; }
    public float AggroRange { get => aggroRange; set => aggroRange = value; }
    public float LastDamageFrame { get => lastDamageFrame; set => lastDamageFrame = value; }
    public int MaxHp { get => maxHp; set => maxHp = value; }

    public void OnAttacked(OnAttackedArgs args)
    {
        if (args.damage == 0) //Knockback
        {
            /*int forceStrength = 500;
            Vector3 force = transform.position - args.attacker.transform.position;
            force.Normalize();
            rb.AddForce(forceStrength * force);*/
        }
        else //Soul damage
        {
            hp -= args.damage;
        }
    }


}
