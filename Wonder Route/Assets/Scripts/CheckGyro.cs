using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGyro : MonoBehaviour
{
    void Start()
    {
        if (!Input.gyro.enabled)
        {
            gameObject.SetActive(false);
        }
    }
}