using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : MonoBehaviour
{
    [SerializeField] GameObject EndF;
    [SerializeField] GameObject EndG;
    [SerializeField] GameObject EndN;

    private void Start()
    {
        int index = GameManager.Instance.selectedCharacter;

        if (index == 0) EndF.SetActive(true);
        else if (index == 1) EndG.SetActive(true);
        else if (index == 2) EndN.SetActive(true);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenu");
        }
    }
}
