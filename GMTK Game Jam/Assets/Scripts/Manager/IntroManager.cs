using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    [SerializeField] DialogBox dialogBox;
    bool isCharacterPicked;
    bool isStoryComplete = false;
    GameManager gameManager;
    [SerializeField] private GameObject selectionCharacter;
    [SerializeField] private float timer;
    private void Awake()
    {
        
    }

    private void Start()
    {
        StartCoroutine(IntroText());       
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (isStoryComplete)
        {
            selectionCharacter.SetActive(true);
        }

        if (isCharacterPicked && isStoryComplete)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
        }
    }

    private IEnumerator IntroText()
    {
        string text = "You used to be a cheerful and joyful person, but the negativity and bad mood of people around finally broke you.\n\n" +
            "However you won't stay like that forever. You want to recover your past self and to do so you will take care of the root of the problem, making those around you join yourself toward the light.\n\n" +
            "Helping you in the process to get back the full extend of your soul.";
        StartCoroutine(dialogBox.TypeDialog(text));
        yield return new WaitForSeconds(10f);      
    }

    public void PressSkipButton()
    {
        isStoryComplete = true;
    }

    public void PickCharacterF()
    {
        GameManager.Instance.selectedCharacter = 0;
        isCharacterPicked = true;
    }

    public void PickCharacterG()
    {
        GameManager.Instance.selectedCharacter = 1;
        isCharacterPicked = true;
    }

    public void PickCharacterN()
    {
        GameManager.Instance.selectedCharacter = 2;
        isCharacterPicked = true;
    }
}
