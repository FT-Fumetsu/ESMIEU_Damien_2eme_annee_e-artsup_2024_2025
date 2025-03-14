using PlayerStats;
using System;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    private static SaveSystem _instance;
    public static SaveSystem Instance => _instance;

    public static string _filePath;

    private void Awake()
    {
        _filePath = $"{Application.persistentDataPath}/SaveData.json";
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    [ContextMenu("Save")]
    public void Save()
    {
        SaveData data = new()
        {
            PlayerDTO = FindFirstObjectByType<Player>().Serialized()
        };

        try
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            using FileStream stream = new(_filePath, FileMode.Create);
            using StreamWriter writer = new (stream);
            writer.Write(json);
            Debug.Log("Save Succed");
        }
        catch (Exception ex)
        {
            Debug.LogError($"JSON Serialisation Error: {ex.Message}");
        }
    }

    [ContextMenu("Load")]
    public void Load()
    {
        try
        {
            using StreamReader reader = new (_filePath);
            string json = reader.ReadToEnd();

            SaveData data = JsonConvert.DeserializeObject<SaveData>(json);
            FindFirstObjectByType<Player>().Deserialize(data.PlayerDTO);

            Debug.Log("Load Succed");
        }
        catch (Exception ex)
        {
            Debug.LogError($"JSON Deserialisation Error: {ex.Message}");
        }
    }
}
