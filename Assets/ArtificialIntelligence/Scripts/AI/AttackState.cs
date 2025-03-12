using UnityEngine;
using UnityEngine.EventSystems;

namespace StateMachine
{
    public class AttackState : IState
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
            
            Vector2 moveDirection = Vector2.down * enemyStateMachineData.enemyVerticalSpeed * Time.deltaTime;
            float directionX = Mathf.Sign(enemyStateMachineData.playerTransform.position.x - enemyStateMachineData.enemyTransform.position.x);
            moveDirection.x = directionX * enemyStateMachineData.enemyHorizontalSpeed * Time.deltaTime;

            enemyStateMachineData.enemyTransform.Translate(moveDirection);

            return null;
        }
    }
}