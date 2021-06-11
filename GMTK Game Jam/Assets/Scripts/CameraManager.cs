using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] float offsetX;
    [SerializeField] float offsetY;
    
    float cameraSize;
    [SerializeField] Player player;
    //[SerializeField] Soul soul;

    private void Start()
    {
        cameraSize = GetComponent<Camera>().orthographicSize;
    }

    private void Update()
    {
        CenterCamera();
    }

    public void CenterCamera()
    {
        //if(player.isLinked)
        transform.position = player.transform.position + new Vector3(offsetX, offsetY, -1);
    }
}
