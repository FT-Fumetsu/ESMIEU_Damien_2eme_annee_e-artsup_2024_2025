using UnityEngine;

namespace StateMachine
{
    public class AttackEnemyStateMachineData : IStateMachineData
    {
        public Transform EnemyTransform;
        public Transform PlayerTransform;
        public float Speed;
        public float DetectionRadius;
    }
}