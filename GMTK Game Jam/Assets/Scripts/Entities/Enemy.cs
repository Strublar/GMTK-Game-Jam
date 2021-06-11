using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity, IAttackable
{

    public float AggroRange;
    public int Hp { get ; set; }

    public void OnAttacked(int damage)
    {
        throw new System.NotImplementedException();
    }

    public void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.SendMessage("OnAttacked", this.attack);
    }
}
