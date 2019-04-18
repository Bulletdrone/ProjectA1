using System.Collections;
using System.Collections.Generic;
using UnityEngine.Android;
using UnityEngine;

public class Tracking : MonoBehaviour
{
    public int maxDistance;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartGPSTracker());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartGPSTracker()
    {
        yield return new WaitForSeconds(3);

        if (!Input.location.isEnabledByUser)
            yield break;

        Input.location.Start(maxDistance);

        int waitUntilTimeOut = 20;

        while(Input.location.status == LocationServiceStatus.Initializing && waitUntilTimeOut > 0)
        {
            yield return new WaitForSeconds(1);
            Debug.Log (Input.location.status);
            waitUntilTimeOut--;
        }

        if (waitUntilTimeOut < 1)
        {
            Debug.Log("Timed Out");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Failed to launch locationservice");
            yield break;
        }
        if (Input.location.status == LocationServiceStatus.Running)
        {
            Debug.Log(Input.location.status);
            //Debug.Log("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
        }
        else
        {
            Debug.Log("Nothing Happens");
        }


    }
}
