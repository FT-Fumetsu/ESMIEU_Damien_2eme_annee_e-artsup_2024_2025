using UnityEngine;

namespace StateMachine
{
    public class PassiveState : IState
    {
        public void Enter(IStateMachineData stateMachineData) { }

        public IState Update(IStateMachineData stateMachineData)
        {
            var data = (AttackEnemyStateMachineData)stateMachineData;
            float distance = Vector2.Distance(data.EnemyTransform.position, data.PlayerTransform.position);

            if (distance < data.DetectionRadius)
            {
                return new AttackState();
            }                

            data.EnemyTransform.position += Vector3.down * data.Speed * Time.deltaTime;
            return null;
        }

        public void Exit(IStateMachineData stateMachineData) { }
    }
}