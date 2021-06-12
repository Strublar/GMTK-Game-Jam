using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Player player;

    // Update is called once per frame
    void FixedUpdate()
    {
        #region Movement
        Vector3 direction = Vector2.zero;

        direction += Input.GetKey(KeyCode.W) ? Vector3.up : Vector3.zero;
        direction += Input.GetKey(KeyCode.S) ? Vector3.down : Vector3.zero;
        direction += Input.GetKey(KeyCode.A) ? Vector3.left : Vector3.zero;
        direction += Input.GetKey(KeyCode.D) ? Vector3.right : Vector3.zero;

        direction.Normalize();

        player.Move(direction, Time.deltaTime) ;

        //Soul mouvement
        if (player.IsCombined == false)
        {
            player.soul.Move(-direction, Time.deltaTime);
        }
        else
        {
            player.soul.transform.position = player.transform.position;
        }
        #endregion

        




    }

    private void Update()
    {
        #region Projectiles


        if (Input.GetMouseButtonDown(0))
        {
            player.StartCharging();
            Debug.Log("Start charging");
        }
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos = new Vector3(mousePos.x, mousePos.y, 0);
            Vector3 fireDirection = mousePos - player.transform.position;
            fireDirection.Normalize();

            Debug.Log("Fire !");
            player.Fire(fireDirection);
        }

        #endregion
    }
}
