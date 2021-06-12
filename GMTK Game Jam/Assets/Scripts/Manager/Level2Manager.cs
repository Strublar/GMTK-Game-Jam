using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Manager : MonoBehaviour
{
    int step;
    [SerializeField] DialogBox dialogBox;
    [SerializeField] List<Enemy> enemies;
    [SerializeField] Door door;

    bool isEnteredMainHall;
    bool isEnteredOutside;
    bool isEnterCafeteria;

    private void Start()
    {
        step = 0;
        StartCoroutine(Tuto1());
    }

    private IEnumerator Tuto1()
    {
        string text = "You now have a new move. You can throw projectile to keep bad mood people at bay.";
        StartCoroutine(dialogBox.TypeDialog(text));
        yield return new WaitForSeconds(4f);
        text = "To fire, press left mouse button and charge it. The longer you charge, the stronger the push is.";
        StartCoroutine(dialogBox.TypeDialog(text));
        yield return new WaitForSeconds(4f);
        text = "You can also use it to open door. Try it.";
        StartCoroutine(dialogBox.TypeDialog(text));
        yield return new WaitForSeconds(4f);
    }


    private IEnumerator EndTuto()
    {
        string text = "Good Job! Time to spread happyness.";
        foreach (Enemy enemy in enemies)
        {
            enemy.AggroRange = 10f;
        }
        StartCoroutine(dialogBox.TypeDialog(text));
        yield return new WaitForSeconds(4f);
        dialogBox.textBox.SetActive(false);
    }

    private void Update()
    {
        if (door.IsOpen && step == 0)
        {
            step++;
            StopAllCoroutines();
            StartCoroutine(EndTuto());
        }
        if (AllEnemiesAreHappy() && step == 1)
        {
            step++;
            EndLevel();
        }
    }

    private bool AllEnemiesAreHappy()
    {
        foreach (Enemy enemy in enemies)
        {
            if (!enemy.IsHappy) return false;
        }
        return true;
    }

    private void EndLevel()
    {
        dialogBox.textBox.SetActive(true);
        string text = "Congratulations! Time to spread more happyness at your local park.";
        StartCoroutine(dialogBox.TypeDialog(text));
    }
}
