using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public bool IsOpen { get; set; }
    [SerializeField] GameObject doorOpen;
    [SerializeField] GameObject doorClose;
    [SerializeField] BoxCollider2D boxCollider;
    public void OnInteract()
    {
        throw new System.NotImplementedException();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            doorOpen.SetActive(true);
            doorClose.SetActive(false);
            boxCollider.enabled = false;
            IsOpen = true;
        }
    }
}
