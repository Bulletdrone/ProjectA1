using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public List<GameObject> worldScenes;
    public Transform spawnLocation;
    LocationEnum locations;

    void InstantiateWorld()
    {
        switch (locations)
        {
            case LocationEnum.SintLucasIngang:
                Instantiate(worldScenes[0], spawnLocation.position, spawnLocation.rotation);
                break;
            case LocationEnum.bagelnJuice:
                Instantiate(worldScenes[1], spawnLocation.position, spawnLocation.rotation);
                break;
            case LocationEnum.Sportcomplex:
                Instantiate(worldScenes[3], spawnLocation.position, spawnLocation.rotation);
                break;
            case LocationEnum.StationStrijp:
                Instantiate(worldScenes[4], spawnLocation.position, spawnLocation.rotation);
                break;
            case LocationEnum.End:
                Instantiate(worldScenes[5], spawnLocation.position, spawnLocation.rotation);
                break;
            default:
                break;
        }
    }
}
