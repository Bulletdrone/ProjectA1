﻿using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public static LocationEnum locations;
    public bool[,] isItemUnlocked;

    public TextManager _textManager;
    public UIManager _uiManager;

    public Track track;

    public List<GameObject> worldScenes;
    public Transform spawnLocation;

    void Start()
    {
        locations = LocationEnum.SintLucasIngang;
        isItemUnlocked = new bool[(int)LocationEnum.End, 2];
        InstantiateWorld();
    }

    void InstantiateWorld()
    {
        int locInt = (int)locations;
        Debug.Log(locInt);
        //Instantiate(worldScenes[locInt], spawnLocation.position, spawnLocation.rotation);
        _textManager.LocationText(locInt);
        _uiManager.locationUI(locInt);
        UnlockedItems(locInt);

        //switch (locations)
        //{
        //    case LocationEnum.SintLucasIngang:
        //        Instantiate(worldScenes[0], spawnLocation.position, spawnLocation.rotation);
        //        _textManager.LocationText(locInt);
        //        _uiManager.locationUI(locInt);
        //        break;
        //    case LocationEnum.bagelnJuice:
        //        Instantiate(worldScenes[1], spawnLocation.position, spawnLocation.rotation);
        //        _textManager.LocationText(locInt);
        //        _uiManager.locationUI(locInt);
        //        break;
        //    case LocationEnum.Sportcomplex:
        //        Instantiate(worldScenes[3], spawnLocation.position, spawnLocation.rotation);
        //        _textManager.LocationText(locInt);
        //        _uiManager.locationUI(locInt);
        //        break;
        //    case LocationEnum.StationStrijp:
        //        Instantiate(worldScenes[4], spawnLocation.position, spawnLocation.rotation);
        //        _textManager.LocationText(locInt);
        //        _uiManager.locationUI(locInt);
        //        break;
        //    case LocationEnum.End:
        //        Instantiate(worldScenes[5], spawnLocation.position, spawnLocation.rotation);
        //        _textManager.LocationText(locInt);
        //        _uiManager.locationUI(locInt);
        //        break;
        //    default:
        //        break;
        //}
    }

    void UnlockedItems(int locInt)
    {
        bool top = isItemUnlocked[locInt, 0];
        bool bottom = isItemUnlocked[locInt, 1];

        _textManager.SetObjectTexts(top, bottom);
        _uiManager.SetObjectSprites(top, bottom);
    }
}