using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Player player;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = Vector2.zero;

        direction += Input.GetKey(KeyCode.W) ? Vector3.up : Vector3.zero;
        direction += Input.GetKey(KeyCode.S) ? Vector3.down : Vector3.zero;
        direction += Input.GetKey(KeyCode.A) ? Vector3.left : Vector3.zero;
        direction += Input.GetKey(KeyCode.D) ? Vector3.right : Vector3.zero;

        direction.Normalize();

        player.Move(direction, Time.deltaTime) ;

        if(player.isCombined == false)
        {
            player.soul.Move(-direction, Time.deltaTime);
        }
        else
        {
            player.soul.transform.position = player.transform.position;
        }

    }
}
