using System.Collections.Generic;
using GoogleARCore;
using GoogleARCore.Examples.Common;
using UnityEngine;
using UnityEngine.EventSystems;

public class ARController : MonoBehaviour
{
    public Camera FirstPersonCamera;
    public GameObject DetectedPlanePrefab;
    public GameObject LocationPrefab;
    private bool m_IsQuitting = false;

    void Update()
    {
        
    }
}
