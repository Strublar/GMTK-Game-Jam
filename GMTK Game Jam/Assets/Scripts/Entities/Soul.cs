using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : Entity
{
    [SerializeField] private GameObject linkParticles;
    [SerializeField] private Player player;
    [SerializeField] private GameObject linkPrefab;
    [SerializeField] private Link playerLink;
    [SerializeField] private float bumpRadius;
    [SerializeField] private ParticleSystem bumpVFX;

    private List<GameObject> linkList = new List<GameObject>();

    public void Awake()
    {
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            Enemy target = collision.gameObject.GetComponent<Enemy>();
            if(target.IsHappy && !target.hasLink && player.Level >= 3)
            {

                GameObject newLink = Instantiate(linkPrefab, transform);
                newLink.GetComponentInChildren<Link>().Init(5f, target);
                linkList.Add(newLink);

            }
        }
    }

    public void Bump(float force)
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), bumpRadius);
        foreach(Collider2D col in enemies)
        {
            if(col.gameObject.layer == 7)
            {
                Vector2 forceDirection = col.transform.position-player.transform.position;
                forceDirection.Normalize();
                col.GetComponent<Rigidbody2D>().AddForce(forceDirection*force);

            }
        }
        bumpVFX.Play();
    }
    public void Combine()
    {
        foreach(GameObject link in linkList)
        {
            Destroy(link.gameObject);
        }
    }
}
