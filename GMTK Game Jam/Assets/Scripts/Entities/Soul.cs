using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : Entity
{
    [SerializeField] private GameObject linkParticles;
    [SerializeField] private Player player;
    [SerializeField] private GameObject linkPrefab;
    [SerializeField] private Link playerLink;
    private List<GameObject> linkList = new List<GameObject>();

    public void Awake()
    {
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            Enemy target = collision.gameObject.GetComponent<Enemy>();
            if(target.IsHappy && !target.hasLink)
            {

                GameObject newLink = Instantiate(linkPrefab, transform);
                newLink.GetComponentInChildren<Link>().Init(5f, target);
                linkList.Add(newLink);
            }
        }
    }

    public void Combine()
    {
        foreach(GameObject link in linkList)
        {
            Destroy(link.gameObject);
        }
    }
}
