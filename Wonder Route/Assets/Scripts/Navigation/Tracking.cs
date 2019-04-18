using System.Collections;
using System.Collections.Generic;
using UnityEngine.Android;
using UnityEngine.UI;
using UnityEngine;

public class Tracking : MonoBehaviour
{
    public int maxDistance;
    public Text _naviText;
    public Text _statusText;

    public void Tracker()
    {
        StartCoroutine(StartGPSTracker());
        _statusText.text = "Currently tracking";
    }

    IEnumerator StartGPSTracker()
    {
       _naviText.text = "Tracking...";

       yield return new WaitForSeconds(3);

        if (!Input.location.isEnabledByUser)
        {
            _statusText.text = "Currently not tracking";
            yield break;
        }

        Input.location.Start(maxDistance);

        int waitUntilTimeOut = 20;

        while(Input.location.status == LocationServiceStatus.Initializing && waitUntilTimeOut > 0)
        {
            yield return new WaitForSeconds(1);
            _naviText.text = Input.location.status.ToString();
            waitUntilTimeOut--;
        }

        if (waitUntilTimeOut < 1)
        {
            _naviText.text = "Timed Out";
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            _naviText.text = "Failed to launch locationservice";
            yield break;
        }
        if (Input.location.status == LocationServiceStatus.Running)
        {
            //_naviText.text = Input.location.status.ToString();
            _naviText.text = "Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp;
        }
        else
        {
            _naviText.text = "Nothings happening";
        }


    }
}
