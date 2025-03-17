using UnityEngine;
using Serialisation;

namespace PlayerStats
{
    [System.Serializable]
    public class Player : MonoBehaviour, ISerialize<PlayerDTO>
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

        public PlayerDTO Serialized()
        {
            return new PlayerDTO
            {
                Health = this._health,
                Cash = this._cash
            };
        }

        public void Deserialized(PlayerDTO dto)
        {
            this._health = dto.Health;
            this._cash = dto.Cash;
        }

        [ContextMenu("Reset Cash")]
        public void ResetCash()
        {
            _cash = 0;
            Debug.Log("The cash of the player = " + _cash + " !");
        }

    }
}