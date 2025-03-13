using UnityEngine;

namespace StateMachine
{
    public class EnemyStateMachineData : IStateMachineData
    {
        public Transform EnemyTransform;
        public Transform PlayerTransform;
        public float Speed;
        public float DetectionRadius;
    }
}