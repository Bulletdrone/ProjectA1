using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    public Locations locations;

    public int maxDistance;

    [SerializeField] private TextManager textManager;

    public void Tracker()
    {
        textManager.SetText(textManager.statusText, "Currently tracking");
        StartCoroutine(StartGPSTracker());
    }

    IEnumerator StartGPSTracker()
    {
        yield return new WaitForSeconds(3);

        if (!Input.location.isEnabledByUser)
        {
            textManager.SetText(textManager.statusText, "Please enable or allow GPS on this app.");
            yield break;
        }

        Input.location.Start(maxDistance);

        int waitUntilTimeOut = 20;

        while (Input.location.status == LocationServiceStatus.Initializing && waitUntilTimeOut > 0)
        {
            yield return new WaitForSeconds(1);
            waitUntilTimeOut--;
        }

        if (waitUntilTimeOut < 1)
        {
            textManager.SetText(textManager.statusText, "Please enable or allow GPS on this app.");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            textManager.SetText(textManager.statusText, "Please enable or allow GPS on this app.");
            yield break;
        }
        if (Input.location.status == LocationServiceStatus.Running)
        {
            Invoke("TrackLocation", 1f);
        }
        else
        {
        }
    }

    void TrackLocation()
    {
        if (OnLocation())
        {
            textManager.SetText(textManager.statusText, "Je bent dichtbij, swipe naar boven en volg de instructie.");
        }
        else
        {
            textManager.SetText(textManager.statusText, "Je bent nog te ver weg.");
            TrackLocation();
        }
    }

    public bool OnLocation()
    {
        float currentLatitude;
        float currentLongitude;

        float locationLatitude;
        float locationLongitude;

        currentLatitude = Input.location.lastData.latitude;
        currentLongitude = Input.location.lastData.longitude;

        float[] locationGPS;
        locationGPS = locations.GetLocation(WorldManager.locations);

        locationLatitude = locationGPS[0];
        locationLongitude = locationGPS[1];

        if ((MyApproximation(currentLatitude, locationLatitude, 0.0006f)) && MyApproximation(currentLongitude, locationLongitude, 0.0006f))
        {
            return true;
        }
        return false;
    }

    private bool MyApproximation(float a, float b, float tolerance)
    {
        return (Mathf.Abs(a - b) < tolerance);
    }
}