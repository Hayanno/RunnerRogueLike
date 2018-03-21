using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {
    [SerializeField]
    public List<SpawnableObject> spawnableObjects = new List<SpawnableObject>();
    public Transform spawnPoint;
    public float frequency = 0.5f;

    private bool isSpawning = false;
    private float counter = 0.0f;

    void Update() {
        if (!isSpawning) return;

        if (counter <= 0.0f) {
            SpawnObjects();
        } else {
            counter -= Time.deltaTime * frequency;
        }
    }

    private void SpawnObjects() {
        for(int i = 0; i < spawnableObjects.Capacity; i++) {
            if(spawnableObjects[i].ShouldSpawn()) {
                SpawnObject(i);
            }
        }
    }

    private void SpawnObject(int index) {
        ISpawnable currSpawnableObject = spawnableObjects[index];
        Vector3 positionToSpawn = spawnPoint.position + new Vector3(0, currSpawnableObject.GetSpawnPosition(), 0);

        Instantiate(currSpawnableObject.GetGameObject(), positionToSpawn, Quaternion.identity, transform);
    }

    public void StartSpawning() {
        isSpawning = true;
    }

    public void StopSpawning() {
        isSpawning = false;
    }
}
