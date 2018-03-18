using UnityEngine;

public class SpawnObject : MonoBehaviour {
    public Transform spawnPoint;
    public int numberOfBlockFirstSpawn;
    public int numberOfBlocksCycle;

    private int hauteur;
    private int level;

    public void Init(int hauteur, int level) {
        this.hauteur = hauteur;
        this.level = level;
    }

    public Vector3 GetSpawnPointPosition() {
        return spawnPoint.position;
    }
}