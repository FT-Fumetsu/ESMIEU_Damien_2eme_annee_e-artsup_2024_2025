using PlayerStats;
using System;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using Chests;
using System.Collections.Generic;

namespace Serialisation
{
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
                PlayerDTO = FindFirstObjectByType<Player>().Serialized(),
                ChestDTO = new List<ChestDTO>()
            };

            Chest[] chests = FindObjectsOfType<Chest>();
            foreach (Chest chest in chests)
            {
                data.ChestDTO.Add(chest.Serialized());
            }

            try
            {
                string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                using FileStream stream = new(_filePath, FileMode.Create);
                using StreamWriter writer = new(stream);
                writer.Write(json);
                Debug.Log($"Save Succed : {_filePath}");
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
                using StreamReader reader = new(_filePath);
                string json = reader.ReadToEnd();

                SaveData data = JsonConvert.DeserializeObject<SaveData>(json);
                FindFirstObjectByType<Player>().Deserialized(data.PlayerDTO);

                Chest[] chests = FindObjectsOfType<Chest>();

                //Pour tous les ChestDTO dans la liste de ChestDTO dans SaveData
                foreach (ChestDTO chestDTO in data.ChestDTO)
                {
                    //Dans le tableau chests, cherche le premier chest qui correspond à la condition
                    //"c => c.GetID() == chestDTO.ID". Ce qui veut dire: "un coffre dont l'id (c.GetID())
                    //est égal à l'id dans le ChestDTO (== chestDTO.ID).
                    Chest chest = Array.Find(chests, c => c.Id == chestDTO.ID);
                    if (chest != null)
                    {
                        chest.Deserialized(chestDTO);
                    }
                }

                Debug.Log($"Load Succed : {_filePath}");
            }
            catch (Exception ex)
            {
                Debug.LogError($"JSON Deserialisation Error: {ex.Message}");
            }
        }
    }
}