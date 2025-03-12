using UnityEngine;

namespace StateMachine
{
    public class EnemyStateMachineData : IStateMachineData
    {
        public Transform enemyTransform;
        public float enemyVerticalSpeed;
        public float enemyHorizontalSpeed;
        public Transform playerTransform;
    }
}