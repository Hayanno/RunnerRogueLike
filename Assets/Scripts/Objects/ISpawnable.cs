using UnityEngine;
using System.Collections;

public interface ISpawnable {
    Vector3 GetSpawnPointPosition();
    GameObject GetGameObject();

    bool ShouldSpawn();
}
