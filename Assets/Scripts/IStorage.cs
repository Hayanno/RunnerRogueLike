using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStorage {
    int GetInt(string key, int defaultValue);
    void SetInt(string key, int value);
}
