﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGyroo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gameObject.SetActive(false);
        }
    }
}