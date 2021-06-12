using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private Slider keyboardCursor;
    [SerializeField]
    private GameObject menu, credit, settings;

    public void OnPlayClicked()
    {
        SceneManager.LoadScene("Intro");
    }

    public void OnSettingClicked()
    {
        //DoTween make setting appear in this scene, setting are saved into static parameters or playerpref to choose
        credit.SetActive(false);
        settings.SetActive(true);
        menu.SetActive(false);
    }

    public void OnCreditClicked()
    {
        //DOTween make setting appear in this scene
        credit.SetActive(true);
        settings.SetActive(false);
        menu.SetActive(false);
    }

    public void OnQuitClicked()
    {
        Application.Quit();
    }


    public void ReturnToMenu()
    {
        credit.SetActive(false);
        settings.SetActive(false);
        menu.SetActive(true);
    }

    public void OnSelectKeyboard()
    {
        GameManager.Instance.keyboard = keyboardCursor.value == 1 ? 
            GameManager.KeyboardLanguage.azerty :
            GameManager.KeyboardLanguage.qwerty;
    }
}
