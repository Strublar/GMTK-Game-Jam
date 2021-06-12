using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public bool IsOpen { get; set; }

    public void OnInteract()
    {
        throw new System.NotImplementedException();
    }
}
