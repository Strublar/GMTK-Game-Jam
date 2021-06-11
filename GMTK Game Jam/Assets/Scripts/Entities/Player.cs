using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity, IAttackable
{
    public int Hp { get; set; }

    public void OnAttacked(int damage)
    {
        Debug.Log("OUCH");
    }


}
