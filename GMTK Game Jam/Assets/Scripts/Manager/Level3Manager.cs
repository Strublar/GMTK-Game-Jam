using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Manager : MonoBehaviour
{
    int step;
    [SerializeField] private DialogBox dialogBox;
    [SerializeField] List<Enemy> enemies;
    [SerializeField] GameObject endScreenGirl, endScreenBoy, endScreenNeutral;
    private void Start()
    {
        step = 0;
        StartCoroutine(Tuto1());
    }

    private IEnumerator Tuto1()
    {
        string text = "You soul is almost complete. Now, You can link your soul with happy people to create a new link.";
        StartCoroutine(dialogBox.TypeDialog(text));
        yield return new WaitForSeconds(6f);
        dialogBox.textBox.SetActive(false);
        enemies[4].AggroRange = 100;
    }

    private void Update()
    {
        if (AllEnemiesAreHappy() && step == 0)
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
        string text = "You've done it! Your soul is whole again and you helped so many in the process.";
        StartCoroutine(dialogBox.TypeDialog(text));
        yield return new WaitForSeconds(6f);
        //Animation from soul becoming stronger       
        /*switch(GameManager.Instance.selectedCharacter)
        {
            case 0:
                endScreenGirl.SetActive(true);
                break;
            case 1:
                endScreenGirl.SetActive(true);
                break;
            case 2:
                endScreenNeutral.SetActive(true);
                break;
        }*/
        UnityEngine.SceneManagement.SceneManager.LoadScene("End");
    }
}
