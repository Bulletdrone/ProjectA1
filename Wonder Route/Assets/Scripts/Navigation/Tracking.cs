using System.Collections;
using System.Collections.Generic;
using UnityEngine.Android;
using UnityEngine.UI;
using UnityEngine;

public class Tracking : MonoBehaviour
{
    public Locations locations;
    public Location locPos;

    public int maxDistance;

    public Text _naviText;
    public Text _destinationNaviText;

    public Text _statusText;

    void Start()
    {
        locPos = Location.SintLucasIngang;
        float f;
        f = 51.44762f;
        Debug.Log(f);

        //double[] getPos = locations.GetLocation(locPos);

        _destinationNaviText.text = "Latitude: 51.44762 Longitude: 5.45506";
    }

    public void Tracker()
    {
        if (Input.location.isEnabledByUser)
        {
            TrackLocation();
            return;
        }
        _statusText.text = "Currently tracking";

        StartCoroutine(StartGPSTracker());
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

        while (Input.location.status == LocationServiceStatus.Initializing && waitUntilTimeOut > 0)
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
            InvokeRepeating("TrackLocation", 1f, 1f);
        }
        else
        {
            _naviText.text = "Nothings happening";
        }
    }

    void TrackLocation()
    {
        _naviText.text = "Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude;
        if (OnLocation())
        {
            _statusText.text = "You're on your location!";
        }
        else
        {
            _statusText.text = "You're not on your location.";
        }
    }

    public void SetlocPos(Location loc)
    {
        locPos = loc;
    }

    public bool OnLocation()
    {
        float currentLatitude;
        float currentLongitude;

        float locationLatitude;
        float locationLongitude;

        currentLatitude = Input.location.lastData.latitude;
        currentLongitude = Input.location.lastData.longitude;

        //locationLatitude = locationGPS[0];
        //locationLongitude = locationGPS[1];

        locationLatitude = 51.44762f;
        locationLongitude = 5.45506f;

        if ((myApproximation(currentLatitude, locationLatitude, 0.01000f)) && myApproximation(currentLongitude, locationLongitude, 0.01000f))
        {
            return true;
        }

       /* if (currentLatitude - 0.01000 > locationLatitude && currentLatitude + 0.00100 < locationLatitude)
        {
            if (currentLongitude - 0.00100 > locationLongitude && currentLongitude + 0.00100 < locationLongitude)
            {
                return true;
            }
            return false;
        } */
        return false; 
    }

    private bool myApproximation(float a, float b, float tolerance)
    {
        return (Mathf.Abs(a - b) < tolerance);
    }
}
