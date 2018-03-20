using System.Collections.Generic;

public class StorageInMemory : IStorage {
    Dictionary<string, int> data = new Dictionary<string, int>();

    public Dictionary<string, int> Data {
        get {
            return data;
        }
        set {
            data = value;
        }
    }

    public int GetInt(string key, int defaultValue) {
        return Data.ContainsKey(key) ? Data[key] : defaultValue;
    }

    public void SetInt(string key, int value)   {
        Data[key] = value;
    }
}
