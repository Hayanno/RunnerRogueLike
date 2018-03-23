using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {
    [SerializeField]
    public List<SpawnableObject> spawnableObjects = new List<SpawnableObject>();
    public Transform spawnPoint;
    public float frequency = 0.5f;

    private bool isSpawning = false;
    private float counterFrequency = 0.0f;
    private int counterBlocks = 0;

    void Update() {
        if (!isSpawning) return;

        if (counterFrequency <= 0.0f) {
            SpawnObjects();
            counterBlocks++;
        } else {
            counterFrequency -= Time.deltaTime * frequency;
        }
    }

    private void SpawnObjects() {
        for(int i = 0; i < spawnableObjects.Capacity; i++) {
            if(spawnableObjects[i].ShouldSpawn(counterBlocks)) {
                SpawnObject(i);
                counterBlocks++;
            }
        }
    }

    private void SpawnObject(int index) {
        SpawnableObject currSpawnableObject = spawnableObjects[index];
        Vector3 positionToSpawn = spawnPoint.position + new Vector3(0, currSpawnableObject.spawnPosition, 0);

        Instantiate(currSpawnableObject.gameObject, positionToSpawn, Quaternion.identity, transform);
    }

    public void StartSpawning() {
        isSpawning = true;
    }

    public void StopSpawning() {
        isSpawning = false;
    }
}
