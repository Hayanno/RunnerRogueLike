using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnableObject : BaseObject, ISpawnable {
    public SpawnableObject(int hauteur, int level) : base(hauteur, level) {
    }

    public abstract GameObject GetGameObject();
    public abstract int GetSpawnPosition();
    public abstract bool ShouldSpawn();
}
