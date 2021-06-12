using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity, IAttackable
{
    public int Hp { get; set; }
    public bool debug = false;
    public bool isCombined = true;
    public Soul soul;
    public Collider2D soulCollider;
    private bool isSoulInRange = true;
    public SpriteRenderer spriteRenderer;
    public float timerBeforeCombineAgain = 0f;
    
    void Update()
    {
        if(timerBeforeCombineAgain > 0)
        {
            timerBeforeCombineAgain -= Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (isCombined && timerBeforeCombineAgain <= 0)
            {
                isCombined = false;
                timerBeforeCombineAgain = 2f;
            }

            if (!isCombined && timerBeforeCombineAgain <= 0)
            {
                isCombined = true;
                timerBeforeCombineAgain = 2f;
            }
        }


        if(isSoulInRange == false && debug == true)
        {
            spriteRenderer.color = Color.green;
        }

        if(isSoulInRange == true && debug == true)
        {
            spriteRenderer.color = Color.white;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Soul")
        {
            isSoulInRange = true;
        }

    }

    void OnTriggerExit2D(Collider2D col) 
    {
        if (col.name == "Soul")
        {
            isSoulInRange = false;
        }
    }

    public void OnAttacked(int damage)
    {
        Debug.Log("OUCH");
    }

}
