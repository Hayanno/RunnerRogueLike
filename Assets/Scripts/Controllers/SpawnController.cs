using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {
    public float scrollSpeed = 5.0f;
    public GameObject[] spawnObjects;

    private bool isRunning = false;

    void Start() {
        GenerateSpawnObjects();
    }

    void Update() {
        if (!isRunning) return;

        /* GenerateObjects
        if (counter <= 0.0f) {
            GenerateRandomChallenge();
        } else {
            counter -= Time.deltaTime * scrollSpeed;
        }
        */
    }

    public void StartScroll() {
        isRunning = true;
    }

    public void StopScroll() {
        isRunning = false;
    }

    private void GenerateSpawnObjects() {
        int rand = Random.Range(0, spawnObjects.Length);
        GameObject newChallenge = Instantiate(spawnObjects[rand], spawnObjects[rand].GetComponent<SpawnObject>().GetSpawnPointPosition(), Quaternion.identity) as GameObject;
        newChallenge.transform.parent = transform;
    }

    private void ScrollObjects() {
        GameObject currentChild;

        for (int i = 0; i < transform.childCount; i++) {
            currentChild = transform.GetChild(i).gameObject;
            ScrollObject(currentChild);

            if (currentChild.transform.position.x <= -15.0f) {
                Destroy(currentChild);
            }
        }
    }

    private void ScrollObject(GameObject go) {
        go.transform.position -= Vector3.right * (scrollSpeed * Time.deltaTime);
    }
}
