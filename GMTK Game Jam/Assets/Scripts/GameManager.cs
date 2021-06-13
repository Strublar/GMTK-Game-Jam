using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] List<Model> firstCharacter;
    [SerializeField] List<Model> secondCharacter;
    [SerializeField] List<Model> thirdCharacter;
    [HideInInspector] public int selectedCharacter;

    public enum KeyboardLanguage : int
    {
        qwerty = 0,
        azerty = 1
    }
    public KeyboardLanguage keyboard = KeyboardLanguage.qwerty;

    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(this.gameObject);
    }

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public Model GetModel()
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
