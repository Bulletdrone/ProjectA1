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
        GetGPSData();

        for (int i = 0; i < gpsData.GetLength(0); i++)
        {
            Debug.Log(gpsData[i, 0]);
            Debug.Log(gpsData[i, 1]);
        }
    }

    public float[] GetLocation(LocationEnum loc)
    {
        float[] gpsCords = new float[gpsData.GetLength(1)];
        int locInt = (int)loc;

        for (int i = 0; i < gpsCords.Length; i++)
        {
            gpsCords[i] = gpsData[locInt, i];
        }

        return gpsCords;
    }

    [System.Serializable]
    public class LocationInfo
    {
        public int[] cords;
        //public string locName;
    }

    public void GetGPSData()
    {
        GPSDataArray data;
        string dataPath = Application.streamingAssetsPath + "/GPSdata.json";
        string json = File.ReadAllText(dataPath);
        data = JsonUtility.FromJson<GPSDataArray>(json);

        for (int i = 0; i < gpsData.GetLength(0); i++)
        {
            gpsData[i, 0] = data.GPSdata[i].longtitude;
            gpsData[i, 1] = data.GPSdata[i].latitude;
        }
    }
}



//Set GPS data structure.
[System.Serializable]
public struct GPSDataArray
{
    public GPSdata[] GPSdata;
}

[System.Serializable]
public class GPSdata
{
    public float longtitude;
    public float latitude;
}