using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Spawnable", menuName = "Inventory/Spawnable", order = 1)]
public class SpawnableObject : BaseObject, ISpawnable {
    public GameObject gameObject;
    public int nbrOfBlockForSpawning;
    public int nbrBeforeFirstSpawn;
    public int spawnPosition;

    public GameObject GetGameObject() {
        return gameObject;
    }

    public int GetSpawnPosition() {
        return spawnPosition;
    }

    public bool ShouldSpawn(int index) {
        return (index > nbrBeforeFirstSpawn && index % nbrOfBlockForSpawning == 0);
    }
}
