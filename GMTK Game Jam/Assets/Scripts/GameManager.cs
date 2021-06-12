using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [HideInInspector] public Sprite selectedCharacter;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

}
