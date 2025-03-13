using UnityEngine;

namespace StateMachine
{
    public class FleeState : IState
    {
        public void Enter(IStateMachineData stateMachineData) { }

        public IState Update(IStateMachineData stateMachineData)
        {
            var data = (ZigZagEnemyStateMachineData)stateMachineData;
            float distance = Vector2.Distance(data.EnemyTransform.position, data.PlayerTransform.position);

            if (distance > data.DetectionRadius)
                return new ZigZagState();

            Vector3 fleeDirection = (data.EnemyTransform.position - data.PlayerTransform.position).normalized;
            data.EnemyTransform.position += fleeDirection * data.Speed * Time.deltaTime;
            return null;
        }

        public void Exit(IStateMachineData stateMachineData) { }
    }
}