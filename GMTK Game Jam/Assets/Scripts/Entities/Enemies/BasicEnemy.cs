using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy
{
    private void OnTriggerStay2D(Collider2D other)
    {       
        OnAttackedArgs args = new OnAttackedArgs();
        args.attacker = gameObject;
        args.damage = attack;
        args.splitSoul = false;

        if (other.gameObject.GetComponent<MonoBehaviour>() != null && !IsHappy && other.gameObject.layer!=7)
            other.gameObject.SendMessage("OnAttacked", args,SendMessageOptions.DontRequireReceiver);


    }

    public void Update()
    {
        Vector3 direction = Player.p.transform.position - transform.position;
        if (direction.magnitude <= AggroRange)
        {
            direction.Normalize();
            Move(direction, Time.deltaTime);
        }

        wanderTimer -= Time.deltaTime;
        if (IsHappy && wanderTimer <= 0f)
        {
            wanderTimer = baseWanderTimer;
            Wander();
        }
    }
}
