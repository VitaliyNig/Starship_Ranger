using UnityEngine;

public static class DataManager
{
    public static void Save<T>(string key, T saveData)
    {
        string jsonDataString = JsonUtility.ToJson(saveData, true);
        PlayerPrefs.SetString(key, jsonDataString);
    }

    public static T Load<T>(string key) where T : new()
    {
        if (PlayerPrefs.HasKey(key))
        {
            string loadedData = PlayerPrefs.GetString(key);
            return JsonUtility.FromJson<T>(loadedData);
        }
        else
        {
            return new T();
        }
    }
}