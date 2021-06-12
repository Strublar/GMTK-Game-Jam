using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{
    int Hp { get; set; }

    void OnAttacked(int damage);
}
