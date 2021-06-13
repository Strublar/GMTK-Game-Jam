using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    [SerializeField] DialogBox dialogBox;
    bool isCharacterPicked;
    bool isStoryComplete = true;
    GameManager gameManager;
    [SerializeField] private GameObject selectionCharacter;
    [SerializeField] private float timer;
    private void Awake()
    {
        
    }

    private void Start()
    {
        //StartCoroutine(IntroText());       
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
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
        string text = "You are tired to feel all those negative emotion all the time around you.";
        StartCoroutine(dialogBox.TypeDialog(text));
        yield return new WaitForSeconds(4f);
        text = "The world is such a great place why does everyone only focus on its bad aspect.";
        StartCoroutine(dialogBox.TypeDialog(text));
        yield return new WaitForSeconds(4f);
        text = "That must change let's change the heart of people through sharing our soul with them.";
        StartCoroutine(dialogBox.TypeDialog(text));
        yield return new WaitForSeconds(4f);
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
