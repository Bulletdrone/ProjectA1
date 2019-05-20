using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRot : MonoBehaviour
{

    Quaternion initialRotation;
    Quaternion gyroInitialRotation;
    bool gyroEnabled;

    // Start is called before the first frame update
    void Start()
    {
        initialRotation = transform.rotation;
        Input.gyro.enabled = true;
        gyroInitialRotation = Input.gyro.attitude;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}