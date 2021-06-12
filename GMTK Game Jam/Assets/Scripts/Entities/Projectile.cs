using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Entity
{

    public void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
