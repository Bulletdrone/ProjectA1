using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Locations : MonoBehaviour
{
    //public enum Location {SintLucasIngang, Microlab, PSVStadium, MCdonalds, End};
    float[,] gpsData; // 

    private void Start()
    {
        gpsData = new float[4, 2];

        SetLocation();
    }

    public void SetLocation()
    {
        //Sintlucas Ingang.
        gpsData[0, 0] = 51.44709f;
        gpsData[0, 1] = 5.45474f;
        
        //bagelwinkel.
        gpsData[1, 0] = 51.44762f;
        gpsData[1, 1] = 5.45506f;

        //Sportcomplex
        gpsData[2, 0] = 51.44799f;
        gpsData[2, 1] = 5.45666f;

        //Stationstrijp
        gpsData[3, 0] = 51.44963f;
        gpsData[3, 1] = 5.45770f;

    }

    public float[] GetLocation(Location loc)
    {
        float[] gpsCords = new float[gpsData.GetLength(1)];
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