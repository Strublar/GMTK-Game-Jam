using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    #region Attributes
    public float moveSpeed;
    public int attack;
    public bool hasLink = false;
    #endregion

    #region Methods

    public virtual void Move(Vector3 direction, float duration)
    {
        transform.position += moveSpeed * direction * duration ;
    }

    public virtual void Attack(IAttackable target)
    {

    }

    public virtual void Die()
    {

    }



    #endregion
}
