using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    int step;
    [SerializeField] DialogBox dialogBox;
    [SerializeField] List<Enemy> enemies;
    [SerializeField] GameObject doorClosed;
    [SerializeField] GameObject doorOpen;

    private void Start()
    {
        step = 0;       
        StartCoroutine(Tuto1());
    }

    private IEnumerator Tuto1()
    {
        string text = "You can move around with WASD.";
        if(GameManager.Instance.keyboard == GameManager.KeyboardLanguage.azerty)
        {
            text = "You can move around with ZQSD.";
        }
        
        StartCoroutine(dialogBox.TypeDialog(text));
        yield return null;
    }

    private IEnumerator Tuto2()
    {
        yield return new WaitForSeconds(2f);
        string text = "You can separate from your soul by clicking your left mouse button.";
        StartCoroutine(dialogBox.TypeDialog(text));
        step++;
        yield return null;
    }

    private IEnumerator Tuto3()
    {
        yield return new WaitForSeconds(1f);
        string text = "Your soul follow your mouse cursor.";
        StartCoroutine(dialogBox.TypeDialog(text));
        yield return new WaitForSeconds(4f);
        text = "When separated you lose energy depending from how far your soul is.";
        StartCoroutine(dialogBox.TypeDialog(text));
        yield return new WaitForSeconds(4f);
        text = "To regenerate energy simply reunite with your soul by placing your mouse on top of you.";
        StartCoroutine(dialogBox.TypeDialog(text));
        yield return new WaitForSeconds(5f);
        text = "Last the link betweeen you and your soul bring peace of mind to people. Try to appease your sister next room.";
        StartCoroutine(dialogBox.TypeDialog(text));
    }

    private IEnumerator EndTuto()
    {
        string text = "Good Job! Time to spread happyness.";

        StartCoroutine(dialogBox.TypeDialog(text));
        yield return new WaitForSeconds(3f);
        Destroy(doorClosed);
        doorOpen.SetActive(true);
        foreach (Enemy enemy in enemies)
        {
            enemy.AggroRange = 10f;
        }
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
            if (Input.GetMouseButtonDown(0))
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
            StartCoroutine(EndLevel());
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

    private IEnumerator EndLevel()
    {
        dialogBox.textBox.SetActive(true);
        string text = "Congratulations! You feel more confident by helping your familly.";
        StartCoroutine(dialogBox.TypeDialog(text));
        yield return new WaitForSeconds(4f);
        text = "Your soul is growing.";
        StartCoroutine(dialogBox.TypeDialog(text));
        yield return new WaitForSeconds(3f);
        //Animation from soul becoming stronger
        text = "Time to tackle a harder challenge at your school.";
        StartCoroutine(dialogBox.TypeDialog(text));
        yield return new WaitForSeconds(4f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
    }
}
