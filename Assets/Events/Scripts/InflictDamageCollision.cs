using UnityEngine;
using Health;
using Player;

namespace Enemy
{
    public class InflictDamageCollision : MonoBehaviour
    {
        [SerializeField] private HealthPoint _healthPoints;
        [SerializeField] private CharacterBehaviour _characterBehaviour;

        private void OnTriggerEnter(Collider other)
        {
            _healthPoints.LoseHealthEvent?.Invoke();
        }
    }
}