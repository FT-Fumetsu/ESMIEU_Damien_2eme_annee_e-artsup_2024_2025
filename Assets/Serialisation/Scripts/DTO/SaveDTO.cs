using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerStats;
using Chests;

namespace Serialisation
{
    public class SaveDTO : MonoBehaviour
    {
        [SerializeField] private Player _player = new Player();
        [SerializeField] private List<Chest> _chests = new List<Chest>();

        public void SaveToJson()
        {
            string playerDTO = JsonUtility.ToJson(_player);
            string chestDTO = JsonUtility.ToJson(_chests);
            string newPath = Application.persistentDataPath + "/PlayerAndChestsDTO.json";
            Debug.Log(newPath);
            System.IO.File.WriteAllText(newPath, playerDTO);
            System.IO.File.WriteAllText(newPath, chestDTO);
            Debug.Log("Save completed");
        }
    }
}