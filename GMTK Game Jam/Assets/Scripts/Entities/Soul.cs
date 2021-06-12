using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : Entity
{
    [SerializeField] private GameObject linkParticles;
    [SerializeField] private Player player;

    public void Update()
    {
        linkParticles.transform.LookAt(player.transform);
        float distance = Vector3.Distance(transform.position, player.transform.position);
        linkParticles.transform.localScale = new Vector3(1, 1, distance / 5f);
    }
}
