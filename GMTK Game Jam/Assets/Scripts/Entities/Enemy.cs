using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity, IAttackable
{

    public float AggroRange;
    public int Hp { get ; set; }

    public void OnAttacked()
    {
        throw new System.NotImplementedException();
    }
}
