using UnityEditor;
using UnityEngine;

public class Gold : SpawnableObject, ICollectable {
    public Gold(int hauteur, int level) : base(hauteur, level) {
        
    }

    public override GameObject GetGameObject() {
        throw new System.NotImplementedException();
    }

    public override int GetSpawnPosition() {
        throw new System.NotImplementedException();
    }

    public override bool ShouldSpawn() {
        throw new System.NotImplementedException();
    }
}
