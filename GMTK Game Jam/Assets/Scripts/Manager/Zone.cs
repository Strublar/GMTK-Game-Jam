using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    [SerializeField] List<Enemy> enemies;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            foreach(Enemy enemy in enemies)
            {
                enemy.AggroRange = 50;
            }
        }
    }
}
