using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    [SerializeField] private Player player;
    public void OnAttacked(OnAttackedArgs args)
    {
        player.OnAttacked(args);
    }
}
