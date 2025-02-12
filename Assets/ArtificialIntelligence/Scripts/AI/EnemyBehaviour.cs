using UnityEngine;

namespace StateMachine
{
    [RequireComponent(typeof(EnemyMovements))]
    public class EnemyBehaviour : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;

        private IState _currentState;
        private EnemyStateMachineData _enemyStateMachineData;

        private void Start()
        {
            _enemyStateMachineData = new EnemyStateMachineData()
            {
                enemyTransform = transform,
                enemySpeed = _speed,
            };
            TransitionTo(new PassiveState());
        }

        public void TransitionTo(IState newState)
        {
            if (_currentState != null)
            {
                _currentState.Exit(_enemyStateMachineData);
            }
            _currentState = newState;
            _currentState.Enter(_enemyStateMachineData);
        }

        public void Update()
        {
            if (_currentState != null)
            {
                _currentState.Update(_enemyStateMachineData);
            }
        }
    }
}