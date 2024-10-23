using UnityEngine;
using Health;

namespace Enemy
{
    public class TakeDamageCollision : MonoBehaviour
    {
        [SerializeField] private HealthPoint _healthPoints;

        private void OnTriggerEnter(Collider other)
        {
            _healthPoints.LoseHealthEvent?.Invoke();
        }
    }
}