using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public WebCamTexture cam = null;
    public GameObject plane;

    void Start()
    {
        cam = new WebCamTexture ();
        plane.GetComponent<Renderer>().material.mainTexture = cam;
        cam.Play();
    }
}
