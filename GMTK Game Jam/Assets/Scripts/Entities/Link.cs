using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link : MonoBehaviour
{
    [SerializeField] private float dps;
    private BoxCollider2D col;

    public void Awake()
    {
        col = GetComponent<BoxCollider2D>();
    }

    public void Update()
    {
    }

    public void UpdateCollider(Player player, float distance)
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, player.transform.position - transform.position, distance);
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



}
