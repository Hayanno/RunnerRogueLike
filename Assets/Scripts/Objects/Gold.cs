using UnityEngine;
using System.Collections;

public class Gold : BaseObject, ISpawnable, ICollectable {
    public Gold(int hauteur, int level) : base(hauteur, level) {
        
    }

    public Vector3 GetSpawnPointPosition()
    {
        throw new System.NotImplementedException();
    }

    public bool ShouldSpawn()
    {
        throw new System.NotImplementedException();
    }
}
