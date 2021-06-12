using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] float offsetX = 0;
    [SerializeField] float offsetY = 0;
    [SerializeField] float unzoomStrength = 2f;

    Camera camera;
    float defaultCameraSize;
    

    [SerializeField] Player player;
    [SerializeField] Soul soul;
    //[SerializeField] Soul soul;

    private void Start()
    {
        camera = GetComponent<Camera>();
        defaultCameraSize = camera.orthographicSize;
    }

    private void Update()
    {
        CenterCamera();
    }

    public void CenterCamera()
    {
        if (player.IsCombined)
        {
            transform.position = player.transform.position + new Vector3(offsetX, offsetY, -1);
        }
        else
        {
            transform.position = (player.transform.position + soul.transform.position) / 2f + new Vector3(offsetX, offsetY, -1);
            camera.orthographicSize = defaultCameraSize + (player.transform.position - soul.transform.position).magnitude / unzoomStrength;
        }
    }
}
