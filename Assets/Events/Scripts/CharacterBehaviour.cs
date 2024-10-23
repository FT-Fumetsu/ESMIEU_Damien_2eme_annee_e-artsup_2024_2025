using UnityEngine;
using Health;

namespace Player
{    public class CharacterBehaviour : MonoBehaviour
    {
        [SerializeField] private HealthPoint _healthPoint;
        [SerializeField, Range(0, 3)] private int _health;

        private void Awake()
        {
            Health = 3;
        }

        private void Start()
        {
            _healthPoint.LoseHealthEvent += DebugLog;
            _healthPoint.LoseHealthEvent += LoseHealth;
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _healthPoint.LoseHealthEvent?.Invoke();
            }
        }

        public int Health
        {
            get => _health;
            set
            {
                _health = Mathf.Clamp(value, 0, 3);
            }
        }

        private void DebugLog()
        {
            Debug.Log(Health);
        }

        public void LoseHealth()
        {
            Health -= 1;
        }

        private void OnDisable()
        {
            _healthPoint.LoseHealthEvent -= DebugLog;
            _healthPoint.LoseHealthEvent -= LoseHealth;
        }
    }
}