using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link : MonoBehaviour
{
    private Soul soul;
    [SerializeField] private Entity linkedEntity;
    [SerializeField] private float dps;
    [SerializeField] private GameObject particles;
    private BoxCollider2D col;

    public void Awake()
    {
        soul = GameObject.Find("Soul").GetComponent<Soul>();
        col = GetComponent<BoxCollider2D>();
    }

    public void OnDestroy()
    {
        linkedEntity.hasLink = false;
    }

    public void Update()
    {
        UpdateParticles();
        UpdateCollider();
    }

    public void Init(float dps, Entity linkedEntity)
    {
        this.dps = dps;
        this.linkedEntity = linkedEntity;
        linkedEntity.hasLink = true;
    }


    public void UpdateCollider()
    {
        float distance = Vector3.Distance(soul.transform.position,linkedEntity.transform.position);
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, linkedEntity.transform.position - transform.position, distance);
        OnAttackedArgs args;
        args.attacker = this.gameObject;
        args.damage = dps * Time.deltaTime;
        args.splitSoul = false;
        foreach (RaycastHit2D hit in hits)
        {
            if(hit.transform.gameObject.layer == 7)
            {
                hit.transform.gameObject.SendMessage("OnAttacked", args, SendMessageOptions.DontRequireReceiver);
            }
        }
        
        
        //hit.transform.SendMessage("OnAttacked", args, SendMessageOptions.DontRequireReceiver);
    }

    public void UpdateParticles()
    {
        particles.transform.LookAt(linkedEntity.transform);
        float distance = Vector3.Distance(soul.transform.position, linkedEntity.transform.position);
        particles.transform.localScale = new Vector3(1, 1, distance / 5f);
    }



}
