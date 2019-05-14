using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Locations : MonoBehaviour
{
    [SerializeField]
    private Location locationData;

    //public enum Location {SintLucasIngang, Microlab, PSVStadium, MCdonalds, End};
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

    public Vector2 GetLocation(Location loc)
    {
        Vector2 vector2Data = new Vector2();
        int locInt = (int)loc;

        for (int i = 0; i < gpsData.GetLength(0); i++)
        {
            vector2Data = new Vector2(gpsData[i, 0], gpsData[i, 1]);
        }

        return vector2Data;
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