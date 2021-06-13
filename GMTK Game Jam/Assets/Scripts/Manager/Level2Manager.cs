using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Manager : MonoBehaviour
{
    int step;
    [SerializeField] DialogBox dialogBox;
    [SerializeField] List<Enemy> enemies;
    [SerializeField] Door firstDoor;
    [SerializeField] List<Door> outsideDoors;
    bool outsideActivated = false;
    [SerializeField] List<Door> cafeteriaDoors;
    bool cafeteriaActivated = false;

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
        string text = "With a stronger soul, stronger power. You soul can now bump people around.";
        StartCoroutine(dialogBox.TypeDialog(text));
        yield return new WaitForSeconds(5f);
        text = "To activate, press right mouse button when your soul is out. It takes a bit of time to recharge it.";
        StartCoroutine(dialogBox.TypeDialog(text));
        yield return new WaitForSeconds(5f);
    }


    private void EndTuto()
    {
        enemies[0].AggroRange = 15f;
        enemies[1].AggroRange = 15f;
        enemies[2].AggroRange = 15f;
        dialogBox.textBox.SetActive(false);
    }

    private void Update()
    {
        if (firstDoor.IsOpen && step == 0)
        {
            step++;
            StopAllCoroutines();
            EndTuto();
        }
        if (!outsideActivated)
        {
            for(int i = 0; i < outsideDoors.Count; i++)
            {
                if(outsideDoors[i].IsOpen)
                {
                    enemies[3].AggroRange = 15f;
                    enemies[4].AggroRange = 15f;
                    enemies[5].AggroRange = 15f;
                    enemies[6].AggroRange = 15f;
                    outsideActivated = true;
                }
            }
        }
        if (!cafeteriaActivated)
        {
            for (int i = 0; i < cafeteriaDoors.Count; i++)
            {
                if (cafeteriaDoors[i].IsOpen)
                {
                    enemies[7].AggroRange = 15f;
                    enemies[8].AggroRange = 15f;
                    enemies[9].AggroRange = 15f;
                    enemies[10].AggroRange = 15f;
                    cafeteriaActivated = true;
                }
            }
        }

        if (AllEnemiesAreHappy() && step == 1)
        {
            step++;
            StartCoroutine(EndLevel());
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

    private IEnumerator EndLevel()
    {
        dialogBox.textBox.SetActive(true);
        string text = "Amazing! You can feel your soul getting close to whole again.";
        StartCoroutine(dialogBox.TypeDialog(text));
        yield return new WaitForSeconds(4f);
        //Animation from soul becoming stronger
        text = "One last challenge remains at the park.";
        StartCoroutine(dialogBox.TypeDialog(text));
        yield return new WaitForSeconds(4f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level3");
    }
}
