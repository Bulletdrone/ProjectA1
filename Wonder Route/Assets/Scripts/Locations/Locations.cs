using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Locations : MonoBehaviour
{
    public enum Location {SintLucasIngang, Microlab, PSVStadium, MCdonalds, End};
    int[,] gpsData; // 

    void Start()
    {
        gpsData = new int[(int)Location.End - 1, 2];

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
    }

    public int[] GetLocation(Location loc)
    {
        int[] intData = new int[gpsData.GetLength(1)];
        int locInt = (int)loc;

        for (int i = 0; i < intData.Length; i++)
        {
            intData[i] = gpsData[locInt, i];
        }

        return intData;
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