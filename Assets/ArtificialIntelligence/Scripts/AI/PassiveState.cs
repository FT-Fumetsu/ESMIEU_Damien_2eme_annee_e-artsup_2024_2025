using UnityEngine;

namespace StateMachine
{
    public class PassiveState : IState
    {
        public void Enter(IStateMachineData stateMachineData)
        {

        }

        public void Exit(IStateMachineData stateMachineData)
        {

        }

        public IState Update(IStateMachineData stateMachineData)
        {
            var enemyStateMachineData = (EnemyStateMachineData)stateMachineData;
            enemyStateMachineData.enemyTransform.Translate(Vector2.down * enemyStateMachineData.enemyVerticalSpeed * Time.deltaTime);
            return null;
        }
    }
}