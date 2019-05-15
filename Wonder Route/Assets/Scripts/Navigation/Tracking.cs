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
        double f;
        f = 51.44762;
        Debug.Log(f);

        f = f - 0.00100;
        Debug.Log(f);

        //double[] getPos = locations.GetLocation(locPos);

        _destinationNaviText.text = "Latitude: 51.44762 Longitude: 5.45506";
    }

    public void Tracker()
    {
        StartCoroutine(StartGPSTracker());
        _statusText.text = "Currently tracking";
    }

    IEnumerator StartGPSTracker()
    {
        if (Input.location.isEnabledByUser)
        {
            TrackLocation();
        }

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
        OnLocation();
    }

    public void SetlocPos(Location loc)
    {
        locPos = loc;
    }

    public bool OnLocation()
    {
        double currentLatitude;
        double currentLongitude;

        double locationLatitude;
        double locationLongitude;

        currentLatitude = Input.location.lastData.latitude;
        currentLongitude = Input.location.lastData.longitude;

        double[] locationGPS = locations.GetLocation(locPos);

        //locationLatitude = locationGPS[0];
        //locationLongitude = locationGPS[1];

        locationLatitude = 51.44762;
        locationLongitude = 5.45506;

        if (currentLatitude - 0.00100 > locationLatitude && currentLatitude + 0.00100 < locationLatitude)
        {
            if (currentLongitude - 0.00100 > locationLongitude && currentLongitude + 0.00100 < locationLongitude)
            {
                return true;
            }
            return false;
        }
        return false;
    }
}
