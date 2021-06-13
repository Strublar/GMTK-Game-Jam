using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoFrameManager : MonoBehaviour
{
    [SerializeField] Image videoScreen;
    [SerializeField] List<Sprite> frames;
    [SerializeField] float speed;

    [SerializeField] bool loop;

    private void Start()
    {
        StartCoroutine(PlayVideo());
    }

    private IEnumerator PlayVideo()
    {
        foreach(Sprite frame in frames)
        {
            videoScreen.sprite = frame;
            yield return new WaitForSeconds(1 / speed);
        }
        if (loop) StartCoroutine(PlayVideo());
    }


}
