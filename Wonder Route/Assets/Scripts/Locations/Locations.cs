using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locations : MonoBehaviour
{
    public enum Location {SintLucasIngang, Microlab, PSVStadium, MCdonalds, End};
    int[,] gpsData; // 

    void Start()
    {
        gpsData = new int[(int)Location.End - 1, 4];
    }

    public int[] GetLocation(Location loc)
    {
        int[] data = new int[gpsData.GetLength(1)];
        int locInt = (int)loc;

        for (int i = 0; i < data.Length; i++)
        {
            data[i] = gpsData[locInt, i];
        }

        return data;
    }
}
