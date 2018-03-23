using UnityEngine;
using System.Collections;

public interface ISpawanable {
    Vector3 GetSpawnPointPosition();
    bool ShouldSpawn();
}
