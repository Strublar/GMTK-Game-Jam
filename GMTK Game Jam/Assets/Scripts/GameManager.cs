using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] List<Sprite> firstCharacter;
    [SerializeField] List<Sprite> secondCharacter;
    [SerializeField] List<Sprite> thirdCharacter;
    [HideInInspector] public int selectedCharacter;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public Sprite GetSprite()
    {
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        int index;
        if (sceneName == "Level1") index = 0;
        else if (sceneName == "Level2") index = 1;
        else if (sceneName == "Level3") index = 2;
        else return null;

        if (selectedCharacter == 0) return firstCharacter[index];
        else if (selectedCharacter == 1) return secondCharacter[index];
        else if (selectedCharacter == 2) return thirdCharacter[index];
        else return null;
    }

}
