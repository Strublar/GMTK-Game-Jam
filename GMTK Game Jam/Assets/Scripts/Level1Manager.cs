using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    [SerializeField] List<string> introText;
    [SerializeField] GameObject textBox;
    [SerializeField] TextMeshProUGUI textMesh;

    int lettersPerSecond = 30;
    int index;

    private void Start()
    {
        index = 0;       
        StartCoroutine(TypeDialog(introText[index]));
    }

    public IEnumerator TypeDialog(string dialog, float delayInSec = 0f)
    {
        yield return new WaitForSeconds(delayInSec);
        
        textBox.SetActive(true);
        textMesh.text = "";
        foreach (char letter in dialog.ToCharArray())
        {
            textMesh.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }

        yield return new WaitForSeconds(.5f);
    }

    private void Update()
    {
        if(index == 0)
        {
            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) ||
                Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                index++;
                StartCoroutine(TypeDialog(introText[index], 2));
            }
        }
        if(index == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                index++;
                StartCoroutine(TypeDialog(introText[index], 0));
            }
        }
        //to continue once we are setup on the gameplay
    }
}
