using UnityEngine;
using Health;

namespace Player
{    public class CharacterBehaviour : MonoBehaviour
    {
        [SerializeField] private HealthPoint _healthPoint;
        public static int health;

        private void Awake()
        {
            health = 3;
        }

        private void Start()
        {
            _healthPoint.LoseHealthEvent += LoseHealth;
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _healthPoint.LoseHealthEvent?.Invoke();
            }
        }

        public void LoseHealth()
        {
            if(health > 0)
            {
                health -= 1;
                Debug.Log(health);
            }
        }

        private void OnDisable()
        {
            _healthPoint.LoseHealthEvent -= LoseHealth;
        }
    }
}