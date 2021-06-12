using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogBox : MonoBehaviour
{
    public GameObject textBox;
    [SerializeField] TextMeshProUGUI textMesh;
    int lettersPerSecond = 30;

    public IEnumerator TypeDialog(string dialog, float delayInSec = 0f)
    {
        textBox.SetActive(true);
        textMesh.text = "";
        foreach (char letter in dialog.ToCharArray())
        {
            textMesh.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }

        yield return new WaitForSeconds(delayInSec);
    }
}
