using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    int step;
    [SerializeField] DialogBox dialogBox;
    [SerializeField] List<Enemy> enemies;
    [SerializeField] GameObject door;

    private void Start()
    {
        step = 0;       
        StartCoroutine(Tuto1());
    }

    private IEnumerator Tuto1()
    {
        string text = "You can move around with WASD.";
        StartCoroutine(dialogBox.TypeDialog(text));
        yield return null;
    }

    private IEnumerator Tuto2()
    {
        yield return new WaitForSeconds(2f);
        string text = "You can separate from your soul by pressing space.";
        StartCoroutine(dialogBox.TypeDialog(text));
        step++;
        yield return null;
    }

    private IEnumerator Tuto3()
    {
        yield return new WaitForSeconds(1f);
        string text = "Your soul move in the opposite direction of your physical body.";
        StartCoroutine(dialogBox.TypeDialog(text));
        yield return new WaitForSeconds(4f);
        text = "When separated you lose energy depending from how far your soul is.";
        StartCoroutine(dialogBox.TypeDialog(text));
        yield return new WaitForSeconds(4f);
        text = "To regenerate energy simply reunite with your soul by keeping space pressed.";
        StartCoroutine(dialogBox.TypeDialog(text));
        yield return new WaitForSeconds(4f);
        text = "Last your soul bring peace of mind to people.";
        StartCoroutine(dialogBox.TypeDialog(text));
        yield return new WaitForSeconds(4f);
        text = "Try to appease your sister next room.";
        StartCoroutine(dialogBox.TypeDialog(text));
    }

    private IEnumerator EndTuto()
    {
        string text = "Good Job! Time to spread happyness.";
        Destroy(door);
        foreach(Enemy enemy in enemies)
        {
            enemy.AggroRange = 10f;
        }
        StartCoroutine(dialogBox.TypeDialog(text));
        yield return new WaitForSeconds(4f);
        dialogBox.textBox.SetActive(false);
    }

    private void Update()
    {
        if(step == 0)
        {
            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) ||
                Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                step++;
                StartCoroutine(Tuto2());
            }
        }
        if(step == 2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                step++;
                StopAllCoroutines();
                StartCoroutine(Tuto3());
            }
        }
        if(enemies[0].IsHappy && step == 3)
        {
            step++;
            StopAllCoroutines();
            StartCoroutine(EndTuto());
        }
        if (AllEnemiesAreHappy() && step == 4)
        {
            step++;
            //EndLevel();
        }
    }

    private bool AllEnemiesAreHappy()
    {
        foreach(Enemy enemy in enemies)
        {
            if (!enemy.IsHappy) return false;
        }
        return true;
    }
}
