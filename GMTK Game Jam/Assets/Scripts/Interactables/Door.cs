using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool IsOpen { get; set; }
    [SerializeField] GameObject doorOpen;
    [SerializeField] GameObject doorClose;
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] GameObject doorSound;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8 && !IsOpen)
        {
            doorOpen.SetActive(true);
            doorClose.SetActive(false);
            boxCollider.enabled = false;
            IsOpen = true;
            SoundManager.PlaySound(doorSound);
        }
    }
}
