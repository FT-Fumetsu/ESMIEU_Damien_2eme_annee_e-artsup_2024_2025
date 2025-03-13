using UnityEngine;

namespace StateMachine
{
    public class ZigZagState : IState
    {
        public void Enter(IStateMachineData stateMachineData) { }

        public IState Update(IStateMachineData stateMachineData)
        {
            var data = (ZigZagEnemyStateMachineData)stateMachineData;
            float distance = Vector2.Distance(data.EnemyTransform.position, data.PlayerTransform.position);

            if (distance < data.DetectionRadius)
            {
                return new FleeState();
            }

            data.TimeElapsed += Time.deltaTime;
            float xOffset = Mathf.Sin(data.TimeElapsed * data.ZigzagFrequency) * data.ZigzagAmplitude;
            data.EnemyTransform.position += new Vector3(xOffset, -data.Speed * Time.deltaTime, 0);
            return null;
        }

        public void Exit(IStateMachineData stateMachineData) { }
    }
}