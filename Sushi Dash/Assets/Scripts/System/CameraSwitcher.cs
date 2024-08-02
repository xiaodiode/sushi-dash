using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras;
    public int currentCamera;
    void Start()
    {
        for(int i=0; i<cameras.Length; i++){
            cameras[i].gameObject.SetActive(false);
        }
        cameras[0].gameObject.SetActive(true);
        currentCamera = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeCameras(int cameraNumber){
        cameras[currentCamera].gameObject.SetActive(false);
        cameras[cameraNumber].gameObject.SetActive(true);
        currentCamera = cameraNumber;
    }
}
