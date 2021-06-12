using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity, IAttackable
{
    public static Player p;
    public int Hp { get; set; }
    public bool debug = false;
    public bool isCombined = true;
    public Soul soul;
    public Collider2D soulCollider;
    private bool isSoulInRange = true;
    public SpriteRenderer spriteRenderer;
    public float timerBeforeCombineAgain = 0f;
    [SerializeField] private float immunityFrame;
    private float lastDamageFrame;
    [SerializeField] private GameObject model;
    [SerializeField] private Rigidbody2D rb;

    public float ImmunityFrame { get => immunityFrame; set => immunityFrame = value; }
    public float LastDamageFrame { get => lastDamageFrame; set => lastDamageFrame = value; }


    void Update()
    {
        #region Timer combine
        if (timerBeforeCombineAgain > 0)
        {
            timerBeforeCombineAgain -= Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (isCombined && timerBeforeCombineAgain <= 0)
            {
                isCombined = false;
                timerBeforeCombineAgain = 2f;
            }

            if (!isCombined && timerBeforeCombineAgain <= 0)
            {
                isCombined = true;
                timerBeforeCombineAgain = 2f;
            }
        }


        if(isSoulInRange == false && debug == true)
        {
            spriteRenderer.color = Color.green;
        }

        if(isSoulInRange == true && debug == true)
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
    

    public void Awake()
    {
        p = this;
    }
    public void Start()
    {
        lastDamageFrame = immunityFrame;
        
    }
    public void OnAttacked(OnAttackedArgs args)
    {
        if(lastDamageFrame>immunityFrame)
        {
            Debug.Log("OUCH i got hit by "+args.attacker.name);
            lastDamageFrame = 0;
            int forceStrength = 1500;
            Vector3 force = transform.position - args.attacker.transform.position;
            force.Normalize();
            rb.AddForce(forceStrength*force);
        }
    }

}
