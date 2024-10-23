using UnityEngine;
using UnityEngine.UI;
using Health;

namespace UserInterface
{
    public class HealthBarUI : MonoBehaviour
    {

        [SerializeField] private HealthPoint _healthPoints;
        [SerializeField] private Slider _slider;
        [SerializeField, Range(0, 3)] private int _maxHealth;
        [SerializeField, Range(0, 3)] private int _health;

        private void Start()
        {
            _maxHealth = 3;
            _health = _maxHealth;
            SetMaxHealth(_maxHealth);
            _healthPoints.LoseHealthEvent += HealthBarUpdate;
        }

        public void SetMaxHealth(int health)
        {
            _slider.maxValue = health;
            _slider.value = health;
        }

        public void SetHealth(int health)
        {
            _slider.value = health;
        }

        private void HealthBarUpdate()
        {
            if(_health > 0)
            {
                _health -= 1;

                SetHealth(_health);
            }
        }

        private void OnDisable()
        {
            _healthPoints.LoseHealthEvent -= HealthBarUpdate;
        }
    }
}