using UnityEngine;

namespace StateMachine
{
    public class ZigZagEnemyStateMachineData : IStateMachineData
    {
        public Transform EnemyTransform;
        public Transform PlayerTransform;
        public float Speed;
        public float DetectionRadius;
        public float ZigzagAmplitude;
        public float ZigzagFrequency;
        public float TimeElapsed;
    }
}