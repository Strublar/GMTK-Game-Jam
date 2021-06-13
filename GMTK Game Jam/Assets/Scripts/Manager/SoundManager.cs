using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager
{

    public static void PlaySound(GameObject sound)
    {
        AudioSource[] sources = sound.GetComponents<AudioSource>();
        sources[Random.Range(0, sources.Length - 1)].Play();
    }
}
