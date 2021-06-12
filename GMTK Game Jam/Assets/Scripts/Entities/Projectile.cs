using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Entity
{
    [SerializeField] private float lifeTime;
    [SerializeField] List<Sprite> sprites;
    [SerializeField] SpriteRenderer spriteRenderer; 

    private bool hasImpact = false;
    private float currentLifeTime;
    public Vector3 direction;

    private void Start()
    {
        int index = Random.Range(0, sprites.Count);
        spriteRenderer.sprite = sprites[index];
    }

    public void Update()
    {
        if(hasImpact) currentLifeTime += Time.deltaTime;
        if (currentLifeTime >= lifeTime)
            Destroy(this.gameObject);
        //Move(direction, Time.deltaTime);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        /*OnAttackedArgs args = new OnAttackedArgs();
        args.attacker = gameObject;
        args.damage = attack;
        other.gameObject.SendMessage("OnAttacked", args);*/

        //Destroy(this.gameObject);
        hasImpact = true;
    }

    public void Throw(Vector3 direction, float currentForce)
    {
        this.GetComponent<Rigidbody2D>().AddForce(direction * currentForce);
    }

    
}
