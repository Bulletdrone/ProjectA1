using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Locations : MonoBehaviour
{
    [SerializeField]
    private Location locationData;

    //public enum Location {SintLucasIngang, Microlab, PSVStadium, MCdonalds, End};
    double[,] gpsData; // 

    void Start()
    {
        gpsData = new double[4, 2];

        SetLocation();
    }

    public void SetLocation()
    {
        for (int i = 0; i < gpsData.GetLength(0); i++)
        {
            gpsData[i, 0] = i + 1;
            Debug.Log(gpsData[i, 0]);
            gpsData[i, 1] = i + 2;
            Debug.Log(gpsData[i, 1]);
        }
        gpsData[0, 0] = 51.44761661871976;
    }

    public double[] GetLocation(Location loc)
    {
        double[] gpsCords = new double[gpsData.GetLength(1)];
        int locInt = (int)loc;

        for (int i = 0; i < gpsCords.Length; i++)
        {
            gpsCords[i] =  gpsData[locInt, i];
        }

        return gpsCords;
    }

    [System.Serializable]
    public class LocationInfo
    {
        public int[] cords;
        //public string locName;
    }

    [System.Serializable]
    public struct LocationCollection
    {
        public LocationInfo[] locationCollection;
    }
}