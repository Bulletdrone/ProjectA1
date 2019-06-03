using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public List<GameObject> worldScenes;
    public GameObject spawnLocation;
    Location locations;

    void InstantiateWorld()
    {
        switch (locations)
        {
            case Location.SintLucasIngang:
                //Instantiate(worldScenes[0], spawnLocation.positio);
                break;
            case Location.bagelnJuice:
                break;
            case Location.Sportcomplex:
                break;
            case Location.StationStrijp:
                break;
            case Location.End:
                break;
            default:
                break;
        }
    }
}
