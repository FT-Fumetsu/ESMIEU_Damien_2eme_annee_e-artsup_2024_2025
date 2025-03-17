using System;
using UnityEngine;
using PlayerStats;
using Serialisation;

namespace Chests
{
    [Serializable]
    public class Chest : MonoBehaviour, ISerialize<ChestDTO>
    {
        [SerializeField, Range(0, 10)] private int _obtenableCash;
        [SerializeField] private bool _isChestOpen;
        [SerializeField] private Player _player;

        private string _id;

        public string Id { get { return _id; } }

        private void Awake()
        {
            if (string.IsNullOrEmpty(_id))
                _id = Guid.NewGuid().ToString();
        }

        public ChestDTO Serialized()
        {
            return new ChestDTO
            {
                ObtenableCash = this._obtenableCash,
                IsChestOpen = this._isChestOpen,
                ID = this._id
            };
        }

        public void Deserialized(ChestDTO dto)
        {
            this._obtenableCash = dto.ObtenableCash;
            this._isChestOpen = dto.IsChestOpen;
            this._id = dto.ID;
        }

        [ContextMenu("Open Or Close Chest")]
        public void OpenOrCloseChest()
        {
            if (_isChestOpen)
            {
                _isChestOpen = false;
                Debug.Log("Closed Chest");
            }
            else
            {

                _isChestOpen = true;
                Debug.Log("Opened Chest");
            }

        }

        [ContextMenu("Give Cash")]
        public void GiveCash()
        {
            if (_isChestOpen)
            {
                _player.Cash += _obtenableCash;
                _obtenableCash = 0;
                Debug.Log("Cash gived to Player. The total cash of the player = " +  _player.Cash + " !");
            }
            else
            {
                Debug.Log("Chest is closed, can't give the cash");
            }
        }

        [ContextMenu("Refill Cash")]
        public void RefillCash()
        {
            if (_isChestOpen)
            {
                _obtenableCash = 10;
                Debug.Log("Cash gived to PlayerStats");
            }
            else
            {
                Debug.Log("Chest is closed, can't refill the cash");
            }
        }
    }
}