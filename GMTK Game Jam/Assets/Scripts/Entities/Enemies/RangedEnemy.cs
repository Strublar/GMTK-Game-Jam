using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    [SerializeField] private float throwStrength;
    [SerializeField] private float fleeRange, fireDelay;
    private float baseFireDelay;

    [SerializeField] private AudioSource throwSound;
    [SerializeField] private GameObject projectilePrefab, projectileContainer;



    public void Awake()
    {
        baseFireDelay = fireDelay;
    }
    private void OnTriggerStay2D(Collider2D other)
    {       
        OnAttackedArgs args = new OnAttackedArgs();
        args.attacker = gameObject;
        args.damage = attack;
        args.splitSoul = false;

        if (other.gameObject.GetComponent<MonoBehaviour>() != null && !IsHappy && other.gameObject.layer!=7)
            other.gameObject.SendMessage("OnAttacked", args,SendMessageOptions.DontRequireReceiver);

    }

    public override void Update()
    {
        //base.Update();



        #region Mouvement
        Vector2 direction = Player.p.transform.position - transform.position;
        if (direction.magnitude <= AggroRange && direction.magnitude >= fleeRange+.5f) 
        {
            direction.Normalize();
            Move(direction, Time.deltaTime);
        }
        else if(direction.magnitude <= fleeRange-.5f)
        {
            direction.Normalize();
            Move(-direction, Time.deltaTime);
        }

        #endregion

        #region Fire
        fireDelay -= Time.deltaTime;
        if(fireDelay<=0 && direction.magnitude <= AggroRange && !IsHappy)
        {
            GameObject newProjectile = Instantiate(projectilePrefab, transform.position, transform.rotation, 
                projectileContainer.transform);

            direction.Normalize();
            newProjectile.GetComponent<Projectile>().Throw(direction, throwStrength);
            throwSound.Play();
            fireDelay = baseFireDelay;
        }
        

        #endregion

        #region Wander

        wanderTimer -= Time.deltaTime;
        if (IsHappy && wanderTimer <= 0f)
        {
            wanderTimer = baseWanderTimer;
            Wander();
        }
        #endregion

    }


}
