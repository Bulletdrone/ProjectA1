using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public static LocationEnum locations;

    public TextManager _textManager;
    public List<GameObject> worldScenes;
    public Transform spawnLocation;

    void InstantiateWorld()
    {
        switch (locations)
        {
            case LocationEnum.SintLucasIngang:
                Instantiate(worldScenes[0], spawnLocation.position, spawnLocation.rotation);
                _textManager.LocationText();
                break;
            case LocationEnum.bagelnJuice:
                Instantiate(worldScenes[1], spawnLocation.position, spawnLocation.rotation);
                _textManager.LocationText();
                break;
            case LocationEnum.Sportcomplex:
                Instantiate(worldScenes[3], spawnLocation.position, spawnLocation.rotation);
                _textManager.LocationText();
                break;
            case LocationEnum.StationStrijp:
                Instantiate(worldScenes[4], spawnLocation.position, spawnLocation.rotation);
                _textManager.LocationText();
                break;
            case LocationEnum.End:
                Instantiate(worldScenes[5], spawnLocation.position, spawnLocation.rotation);
                _textManager.LocationText();
                break;
            default:
                break;
        }
    }
}
