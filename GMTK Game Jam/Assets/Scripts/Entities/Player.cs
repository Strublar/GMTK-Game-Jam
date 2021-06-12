using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity, IAttackable
{
    public static Player p;

    [SerializeField] private int hp;
    [SerializeField] private float immunityFrame;
    private float lastDamageFrame;
    [SerializeField] private GameObject model;
    [SerializeField] private Rigidbody2D rb;

    public int Hp { get => hp; set => hp = value; }
    public float ImmunityFrame { get => immunityFrame; set => immunityFrame = value; }
    public float LastDamageFrame { get => lastDamageFrame; set => lastDamageFrame = value; }

    public void Awake()
    {
        p = this;
    }
    public void Start()
    {
        lastDamageFrame = immunityFrame;
        
    }
    public void Update()
    {
        rb.velocity *= 0.9f;
        lastDamageFrame += Time.deltaTime;
        model.SetActive(true);
        int flashPerSecond = 3;
        if(lastDamageFrame < immunityFrame)
        {
            if((lastDamageFrame * flashPerSecond - Mathf.Floor(lastDamageFrame * flashPerSecond))<0.5f)
            {
                model.SetActive(false);
            }
            else
            {
                model.SetActive(true);
            }
        }
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
