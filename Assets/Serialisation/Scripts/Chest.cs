using System;
using UnityEngine;
using PlayerStats;

namespace Chests
{
    [Serializable]
    public class Chest : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] private int _obtenableCash;
        [SerializeField] private bool _isChestOpen;
        [SerializeField] private string _id;

        [SerializeField] private Player _player;

        private void Awake()
        {
            if (string.IsNullOrEmpty(_id))
                _id = Guid.NewGuid().ToString();
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