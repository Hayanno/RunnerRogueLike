using UnityEngine;

public interface ISpawnable {
    GameObject GetGameObject();
    int GetSpawnPosition();
    bool ShouldSpawn();
}
