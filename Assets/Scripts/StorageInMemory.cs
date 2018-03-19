using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageInMemory : IStorage {
    Dictionary<string, int> data = new Dictionary<string, int>();

    public int GetInt(string key, int defaultValue) {
        if (data.ContainsKey(key))
            return data[key];
        else
            return defaultValue;
    }

    public void SetInt(string key, int value) {
        data[key] = value;
    }
}
