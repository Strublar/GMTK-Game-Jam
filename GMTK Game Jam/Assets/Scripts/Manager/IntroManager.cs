using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    [SerializeField] DialogBox dialogBox;
    bool isCharacterPicked;
    bool isStoryComplete = true;
    GameManager gameManager;
    [SerializeField] List<Sprite> sprites;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        //StartCoroutine(IntroText());
    }

    private void Update()
    {
        if(isCharacterPicked && isStoryComplete)
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
        if (gameManager != null) gameManager.selectedCharacter = 0;
        isCharacterPicked = true;
    }

    public void PickCharacterG()
    {
        if (gameManager != null) gameManager.selectedCharacter = 1;
        isCharacterPicked = true;
    }

    public void PickCharacterN()
    {
        if (gameManager != null) gameManager.selectedCharacter = 2;
        isCharacterPicked = true;
    }
}
