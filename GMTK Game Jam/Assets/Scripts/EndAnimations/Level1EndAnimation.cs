using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1EndAnimation : MonoBehaviour
{

    [SerializeField] Camera mainCamera;
    [SerializeField] float targetZoom;
    [SerializeField] float zoomSpeed;
    private bool isZooming = false;
    void OnEnable()
    {
        Zoom();
    }

    public void Update()
    {

        if(isZooming && mainCamera.orthographicSize> targetZoom)
        {
            mainCamera.orthographicSize -= Time.deltaTime * zoomSpeed;
        }
    }

    public void Zoom()
    {

        isZooming = true;
    }
}
