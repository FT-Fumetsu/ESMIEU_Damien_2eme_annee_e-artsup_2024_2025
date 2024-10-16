using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageCollision : MonoBehaviour
{
    [SerializeField] private HealthPoints _healthPoints;

    private void OnTriggerEnter(Collider other)
    {
        _healthPoints.LoseHealthEvent?.Invoke();
    }
}
