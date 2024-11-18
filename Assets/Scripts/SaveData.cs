using UnityEngine;

public static class SaveData
{
    private static string _path = Application.persistentDataPath + "/save_data.json";

    public static void Save(MaterialData data)
    {
        string json = JsonUtility.ToJson(data);
        System.IO.File.WriteAllText(_path, json);
    }

    public static MaterialData Load()
    {
        if (System.IO.File.Exists(_path))
        {
            string json = System.IO.File.ReadAllText(_path);
            return JsonUtility.FromJson<MaterialData>(json);
        }
        return new MaterialData(); // Default values
    }
}