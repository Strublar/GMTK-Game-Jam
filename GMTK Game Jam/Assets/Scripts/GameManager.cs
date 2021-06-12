using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public Sprite selectedCharacter;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

}
