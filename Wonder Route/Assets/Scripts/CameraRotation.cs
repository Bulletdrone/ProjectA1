using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Input.gyro.attitude;
    }
}
