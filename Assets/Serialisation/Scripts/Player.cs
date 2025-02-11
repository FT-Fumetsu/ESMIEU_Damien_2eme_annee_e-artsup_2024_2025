using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerStats
{
    [System.Serializable]
    public class Player : MonoBehaviour
    {
        [SerializeField, Range(0, 100)] private int _health;
        [SerializeField] private int _cash;
        
        public int Cash
        {
            get {  return _cash; }
            set
            {
                if (value < 0)
                {
                    _cash = 0;
                }
                else
                {
                    _cash = value;
                }
            }
        }

        [ContextMenu("Reset Cash")]
        public void ResetCash()
        {
            _cash = 0;
            Debug.Log("The cash of the player = " + _cash + " !");
        }
    }
}