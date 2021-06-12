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
        if(GameManager.Instance.keyboard == GameManager.KeyboardLanguage.qwerty)
        {
            direction += Input.GetKey(KeyCode.W) ? Vector3.up : Vector3.zero;
            direction += Input.GetKey(KeyCode.S) ? Vector3.down : Vector3.zero;
            direction += Input.GetKey(KeyCode.A) ? Vector3.left : Vector3.zero;
            direction += Input.GetKey(KeyCode.D) ? Vector3.right : Vector3.zero;
        }
        else
        {
            direction += Input.GetKey(KeyCode.Z) ? Vector3.up : Vector3.zero;
            direction += Input.GetKey(KeyCode.S) ? Vector3.down : Vector3.zero;
            direction += Input.GetKey(KeyCode.Q) ? Vector3.left : Vector3.zero;
            direction += Input.GetKey(KeyCode.D) ? Vector3.right : Vector3.zero;
        }
        

        direction.Normalize();

        player.Move(direction, Time.deltaTime) ;

        //Soul mouvement
        if (player.IsCombined == false)
        {
            //player.soul.Move(direction, Time.deltaTime);
            if (Input.GetKey(KeyCode.Space))
            {
                Vector3 altDirection = player.transform.position - player.soul.transform.position;
                altDirection.Normalize();
                player.soul.Move(altDirection *2f, Time.deltaTime);
            }

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos = new Vector3(mousePos.x, mousePos.y, 0);
            Vector3 moveDirection = mousePos - player.soul.transform.position;
            if(moveDirection.magnitude >=.5f)
            {
                moveDirection.Normalize();

                Debug.Log("Move !");

                player.soul.Move(moveDirection, Time.deltaTime);
            }
            
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


        if (Input.GetMouseButtonDown(0) && player.Level>=2)
        {
            player.StartCharging();
            Debug.Log("Start charging");
        }
        if (Input.GetMouseButtonUp(0) && player.Level >= 2)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos = new Vector3(mousePos.x, mousePos.y, 0);
            Vector3 fireDirection = mousePos - player.transform.position;
            fireDirection.Normalize();

            Debug.Log("Fire !");
            player.Fire(fireDirection);
        }

        #endregion


        #region Swap with soul
        if (Input.GetMouseButtonUp(1) && player.Level >= 3)
        {
            Vector3 tmpPos = player.transform.position;
            player.transform.position = player.soul.transform.position;
            player.soul.transform.position = tmpPos;
        }
        #endregion

        #region Split
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (player.IsCombined && player.timerBeforeCombineAgain <= 0)
            {
                player.Split();
            }

            /*if (!IsCombined && timerBeforeCombineAgain <= 0 && isSoulInRange)
            {
                IsCombined = true;
                timerBeforeCombineAgain = 2f;
            }*/
        }

        #endregion
    }
}
