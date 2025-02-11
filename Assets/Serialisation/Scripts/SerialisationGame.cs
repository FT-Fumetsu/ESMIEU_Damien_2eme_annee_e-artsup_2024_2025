//using Newtonsoft.Json;
//using System;
//using System.IO;
//using UnityEngine;

//namespace Serialisation
//{
//    public class SerialisationGame : MonoBehaviour
//    {
//        private bool WriteSave(string newPath, SaveDTO saveDTO)
//        {
//            Debug.Log($"Writing savefile to {newPath}");

//            try
//            {
//                string json = JsonConvert.SerializeObject(saveDTO, Formatting.None);

//                Debug.Log($"Write JSON :\n{json}");

//                using FileStream stream = new(newPath, FileMode.Create);
//                using StreamWriter writer = new(stream);
//                writer.Write(json);

//                Debug.Log("Save file done !");

//                return true;
//            }
//            catch (Exception ex)
//            {
//                Debug.LogError("JSON serialization failed\n" + ex);

//                return false;
//            }
//        }

//        private bool ReadSave(string newPath, out SaveDTO saveDTO)
//        {
//            using StreamReader reader = new(newPath);
//            string json = reader.ReadToEnd();

//            Debug.Log($"Read JSON :\n{json}");

//            try
//            {
//                saveDTO = JsonConvert.DeserializeObject<SaveDTO>(json);
//                return true;
//            }
//            catch (Exception ex)
//            {
//                Debug.LogError("JSON deserialization failed\n" + ex);

//                saveDTO = null;
//                return false;
//            }
//        }
//    }
//}