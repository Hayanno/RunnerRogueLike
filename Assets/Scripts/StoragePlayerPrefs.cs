using UnityEngine;
using System.Collections;

public class StoragePlayerPrefs : IStorage {
    public int GetInt(string key, int defaultValue) {
        return PlayerPrefs.GetInt(key, defaultValue);
    }

    public void SetInt(string key, int value) {
        PlayerPrefs.SetInt(key, value);
    }
}
