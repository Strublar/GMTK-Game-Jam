using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity, IAttackable
{
    public static Player p;
    public bool debug = false;
    [SerializeField] private int hp;

    public int Hp { get => hp; set => hp = value; }
    private bool isCombined = true;
    public Soul soul;
    private Collider2D soulCollider;
    private bool isSoulInRange = true;
    private SpriteRenderer spriteRenderer;
    public float timerBeforeCombineAgain = 0f;

    [SerializeField] private float immunityFrame;
    
    [SerializeField] private GameObject model;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject projectilePrefab, projectileContainer;

    [SerializeField] private float minChargeTime;
    [SerializeField] private float maxChargeTime;
    [SerializeField] private int minForce;
    [SerializeField] private int maxForce;

    private float lastDamageFrame;
    private float currentChargeTime;
    private bool isCharging;

    public float ImmunityFrame { get => immunityFrame; set => immunityFrame = value; }
    public float LastDamageFrame { get => lastDamageFrame; set => lastDamageFrame = value; }
    public bool IsCombined { get => isCombined; set => isCombined = value; }

    public void Awake()
    {
        p = this;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        soulCollider = soul.GetComponent<Collider2D>();
    }
    public void Start()
    {
        lastDamageFrame = immunityFrame;

    }

    void Update()
    {
        #region Timer combine
        if (timerBeforeCombineAgain > 0)
        {
            timerBeforeCombineAgain -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsCombined && timerBeforeCombineAgain <= 0)
            {
                IsCombined = false;
                timerBeforeCombineAgain = 2f;
            }

            if (!IsCombined && timerBeforeCombineAgain <= 0)
            {
                IsCombined = true;
                timerBeforeCombineAgain = 2f;
            }
        }


        if (isSoulInRange == false && debug == true)
        {
            spriteRenderer.color = Color.green;
        }

        if (isSoulInRange == true && debug == true)
        {
            spriteRenderer.color = Color.white;
        }
        #endregion

        #region Damage immunity
        rb.velocity *= 0.9f;
        lastDamageFrame += Time.deltaTime;
        model.SetActive(true);
        int flashPerSecond = 3;
        if (lastDamageFrame < immunityFrame)
        {
            if ((lastDamageFrame * flashPerSecond - Mathf.Floor(lastDamageFrame * flashPerSecond)) < 0.5f)
            {
                model.SetActive(false);
            }
            else
            {
                model.SetActive(true);
            }
        }
        #endregion

        #region Charge Throw

        currentChargeTime += isCharging ? Time.deltaTime : 0;
        #endregion
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Soul")
        {
            isSoulInRange = true;
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "Soul")
        {
            isSoulInRange = false;
        }
    }



    public void OnAttacked(OnAttackedArgs args)
    {
        if (lastDamageFrame > immunityFrame)
        {
            Debug.Log("OUCH i got hit by " + args.attacker.name);
            lastDamageFrame = 0;
            int forceStrength = 1500;
            Vector3 force = transform.position - args.attacker.transform.position;
            force.Normalize();
            rb.AddForce(forceStrength * force);
        }
    }
    public void StartCharging()
    {
        currentChargeTime = 0;
        isCharging = true;
    }

    public void Fire(Vector3 direction)
    {
        Debug.Log("Charge time = "+currentChargeTime);
        if (currentChargeTime >= minChargeTime)
        {
            GameObject newProjectile = Instantiate(projectilePrefab, transform.position, transform.rotation, projectileContainer.transform);

            float currentForce = minForce + (maxForce - minForce) 
                * (currentChargeTime - minChargeTime) 
                / (maxChargeTime - minChargeTime);
            currentForce = Mathf.Min(maxForce, currentForce);
            newProjectile.GetComponent<Projectile>().Throw(direction, currentForce);
            
        }

        isCharging = false;

    }


}
