using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void OnPlayClicked()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OnSettingClicked()
    {
        //DoTween make setting appear in this scene, setting are saved into static parameters or playerpref to choose
    }

    public void OnCreditClicked()
    {
        //DOTween make setting appear in this scene
    }

    public void OnQuitClicked()
    {
        Application.Quit();
    }

}
