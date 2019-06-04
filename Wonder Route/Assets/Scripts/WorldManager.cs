using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public List<GameObject> worldScenes;
    public Transform spawnLocation;
    Location locations;

    void InstantiateWorld()
    {
        switch (locations)
        {
            case Location.SintLucasIngang:
                Instantiate(worldScenes[0], spawnLocation.position, spawnLocation.rotation);
                break;
            case Location.bagelnJuice:
                Instantiate(worldScenes[1], spawnLocation.position, spawnLocation.rotation);
                break;
            case Location.Sportcomplex:
                Instantiate(worldScenes[3], spawnLocation.position, spawnLocation.rotation);
                break;
            case Location.StationStrijp:
                Instantiate(worldScenes[4], spawnLocation.position, spawnLocation.rotation);
                break;
            case Location.End:
                Instantiate(worldScenes[5], spawnLocation.position, spawnLocation.rotation);
                break;
            default:
                break;
        }
    }
}
